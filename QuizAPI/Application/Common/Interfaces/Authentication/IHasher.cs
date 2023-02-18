using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Authentication
{
    public interface IHasher
    {
        string Hash(string password, int iterations);
        string Hash(string password);
        bool Verify(string password, string hashedPassword);
    }
}
