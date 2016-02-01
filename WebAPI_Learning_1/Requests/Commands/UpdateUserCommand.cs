using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebAPI_Learning_1.Data.Users;
using WebAPI_Learning_1.Requests.Decorators;

namespace WebAPI_Learning_1.Requests.Commands
{
    public class UpdateUserCommand : IAsyncRequest
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }

    [DoNotValidate]
    public class UpdateUserCommandHandler : AsyncRequestHandler<UpdateUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepo;

        public UpdateUserCommandHandler(IMapper mapper, UserRepository userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        protected override async Task HandleCore(UpdateUserCommand message)
        {
            var user = await _userRepo.GetByIdAsync(message.Id);
            _mapper.Map(message, user);
            user.ModifiedAt = DateTime.UtcNow;
            await _userRepo.UpdateAsync(user);
        }
    }
}