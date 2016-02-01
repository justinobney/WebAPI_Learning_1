using System;
using System.Threading.Tasks;
using MediatR;
using WebAPI_Learning_1.Data.Users;
using WebAPI_Learning_1.Requests.Decorators;

namespace WebAPI_Learning_1.Requests.Commands
{
    public class DeleteUserCommand : IAsyncRequest<User>
    {
        public long Id { get; set; }
    }

    [DoNotValidate]
    public class DeleteUserCommandHandler : IAsyncRequestHandler<DeleteUserCommand, User>
    {
        private readonly UserRepository _userRepo;

        public DeleteUserCommandHandler(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> Handle(DeleteUserCommand message)
        {
            User user = await _userRepo.GetByIdAsync(message.Id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            await _userRepo.DeleteAsync(user);
            return user;
        }
    }
}