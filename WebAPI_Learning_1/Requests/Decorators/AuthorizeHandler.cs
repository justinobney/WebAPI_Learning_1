using System;
using System.Threading.Tasks;
using MediatR;
using WebAPI_Learning_1.Exceptions;
using WebAPI_Learning_1.Interfaces;

namespace WebAPI_Learning_1.Requests.Decorators
{

    public class Authorize : Attribute
    {
    }

    public class AuthorizeHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _inner;
        private readonly IAuthorizer<TRequest> _authorizer;

        public AuthorizeHandler(
            IRequestHandler<TRequest, TResponse> inner,
            IAuthorizer<TRequest> authorizer
            )
        {
            _inner = inner;
            _authorizer = authorizer;
        }

        public TResponse Handle(TRequest message)
        {
            if (_authorizer.Authorize(message))
            {
                return _inner.Handle(message);
            }
            
            throw new AuthorizationException();
        }
    }

    public class AuthorizeHandlerAsync<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse>
        where TRequest : IAsyncRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> _inner;
        private readonly IAuthorizer<TRequest> _authorizer;

        public AuthorizeHandlerAsync(
            IAsyncRequestHandler<TRequest, TResponse> inner,
            IAuthorizer<TRequest> authorizer
            )
        {
            _inner = inner;
            _authorizer = authorizer;
        }

        public Task<TResponse> Handle(TRequest message)
        {
            if (_authorizer.Authorize(message))
            {
                return _inner.Handle(message);
            }

            throw new AuthorizationException();
        }
    }
}