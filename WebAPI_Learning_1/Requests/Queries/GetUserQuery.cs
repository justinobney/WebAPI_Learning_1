using System.Threading.Tasks;
using MediatR;
using WebAPI_Learning_1.Data.Users;

namespace WebAPI_Learning_1.Requests.Queries
{
    public class GetUserQuery : IAsyncRequest<User>
    {
        public long Id { get; set; }
    }

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
}