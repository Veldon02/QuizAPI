using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuizAPI.Data;
using QuizAPI.Data.Helpers;
using QuizAPI.Models;
using QuizAPI.ViewModels;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly TokenValidationParameters _tokenValidationParametors;

        public AuthenticationController(DataContext context, 
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IConfiguration configuration,
            TokenValidationParameters tokenValidationParameters)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _tokenValidationParametors = tokenValidationParameters;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody] RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return BadRequest("Provide all the required fields");

            var userExists = await _userManager.FindByEmailAsync(registerVM.Email);
            if (userExists != null) return BadRequest($"User with email {registerVM.Email} already exists");

            userExists = await _userManager.FindByNameAsync(registerVM.UserName);
            if (userExists != null) return BadRequest($"User with username {registerVM.UserName} already exists");

            var newUser = new User()
            {
                FirstName = registerVM.FisrtName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                UserName = registerVM.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var registrationResult = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (!registrationResult.Succeeded) return BadRequest("Failed to register");

            switch (registerVM.Role)
            {
                case UserRoles.DefaultUser:
                    await _userManager.AddToRoleAsync(newUser, UserRoles.DefaultUser);
                    break;
                default:
                    break;
            }

            return Ok("User created");

            

        }

        [HttpPost("login-user")]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            if (!ModelState.IsValid) return BadRequest("Provide all the required fields");

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null) return BadRequest("There is no user with email " + loginVM.Email);

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginVM.Password);

            if (!isPasswordCorrect) return Unauthorized();

            var token = await GenerateJWTTokenAsync(user,null);

            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequestVM tokenRequestVM)
        {
            if (!ModelState.IsValid) return BadRequest("Provide all the required fields");

            var result = await VerifyAndGenerateTokenAsync(tokenRequestVM);
            return Ok(result);
        }

        private async Task<AuthResultVM> VerifyAndGenerateTokenAsync(TokenRequestVM tokenRequestVM)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var storedToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == tokenRequestVM.RefreshToken);

            var user = await _userManager.FindByIdAsync(storedToken.UserId);

            try
            {
                var tokenCheckResult = jwtTokenHandler.ValidateToken(tokenRequestVM.Token, _tokenValidationParametors, out var validatedToken);
                return await GenerateJWTTokenAsync(user, storedToken);
            }
            catch (SecurityTokenExpiredException)
            {
                if (storedToken.DateExpire >= DateTime.UtcNow)
                    return await GenerateJWTTokenAsync(user, storedToken);
                else
                    return await GenerateJWTTokenAsync(user, null);
            }
        }

        private async Task<AuthResultVM> GenerateJWTTokenAsync(User user, RefreshToken rToken)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach(var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.UtcNow.AddMinutes(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            if (rToken != null)
            {
                return new AuthResultVM()
                {
                    Token = jwtToken,
                    ExpiresAt = token.ValidTo,
                    RefreshToken = rToken.Token
                };
            }

            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                DateAdded = DateTime.UtcNow,
                DateExpire = DateTime.UtcNow.AddMonths(6),
                UserId = user.Id,
                Token = Guid.NewGuid().ToString() + "-+-" + Guid.NewGuid().ToString()
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthResultVM()
            {
                Token = jwtToken,
                ExpiresAt = token.ValidTo,
                RefreshToken = refreshToken.Token
            };
        }
    }
}
