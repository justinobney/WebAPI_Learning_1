using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using WebAPI_Learning_1.Data.Users;

namespace WebAPI_Learning_1.Requests.Commands
{
    public class CreateUserCommand : IAsyncRequest<User>
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserCommandHandler : IAsyncRequestHandler<CreateUserCommand, User>
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepo;

        public CreateUserCommandHandler(IMapper mapper, UserRepository userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<User> Handle(CreateUserCommand message)
        {
            var user = _mapper.Map<User>(message);
            user.CreatedAt = DateTime.UtcNow;
            user.ModifiedAt = DateTime.UtcNow;
            await _userRepo.InsertAsync(user);

            return user;
        }
    }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }

}