using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace WebAPI_Learning_1.Requests.Decorators
{

    public class DoNotValidate : Attribute
    {
    }


    public class ValidateHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _inner;
        private readonly AbstractValidator<TRequest> _validator;

        public ValidateHandler(
            IRequestHandler<TRequest, TResponse> inner,
            AbstractValidator<TRequest> validator
            )
        {
            _inner = inner;
            _validator = validator;
        }

        public TResponse Handle(TRequest message)
        {
            var result = _validator.Validate(message);
            if (result.IsValid)
            {
                return _inner.Handle(message);
            }

            throw new ValidationException(result.Errors);
        }
    }

    public class ValidateHandlerAsync<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse>
        where TRequest : IAsyncRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> _inner;
        private readonly AbstractValidator<TRequest> _validator;

        public ValidateHandlerAsync(
            IAsyncRequestHandler<TRequest, TResponse> inner,
            AbstractValidator<TRequest> validator
            )
        {
            _inner = inner;
            _validator = validator;
        }

        public Task<TResponse> Handle(TRequest message)
        {
            var result = _validator.Validate(message);
            if (result.IsValid)
            {
                return _inner.Handle(message);
            }

            throw new ValidationException(result.Errors);
        }
    }
}