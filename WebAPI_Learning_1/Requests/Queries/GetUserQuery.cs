using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using WebAPI_Learning_1.Data.Users;
using WebAPI_Learning_1.Interfaces;
using WebAPI_Learning_1.Requests.Decorators;

namespace WebAPI_Learning_1.Requests.Queries
{
    public class GetUserQuery : IAsyncRequest<User>
    {
        public long Id { get; set; }
    }

    [Authorize]
    public class GetUserQueryHandler : IAsyncRequestHandler<GetUserQuery, User>
    {
        private readonly UserRepository _userRepo;

        public GetUserQueryHandler(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<User> Handle(GetUserQuery message)
        {
            return _userRepo.GetByIdAsync(message.Id);
        }
    }

    public class GetUserQueryAuthorizer : IAuthorizer<GetUserQuery>
    {
        public bool Authorize(GetUserQuery message)
        {
            return true;
        }
    }

    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}