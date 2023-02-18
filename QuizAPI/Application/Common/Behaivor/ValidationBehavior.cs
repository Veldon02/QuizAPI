using Domain.Common.Errors;
using FluentValidation;
using MediatR;
using OneOf;

namespace Application.Common.Behaivor
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IOneOf
    {
        private readonly IValidator<TRequest>? _validator;
        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle
            (TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validator == null) return await next();
            var validationResult = await _validator.ValidateAsync(request);

            if (validationResult.IsValid) return await next();

            var firstError = validationResult.Errors.First();
            return (dynamic)new ValidationError(firstError.PropertyName, firstError.ErrorMessage);
        }
    }
}
