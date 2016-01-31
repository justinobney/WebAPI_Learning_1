using System.Linq;
using MediatR;
using WebAPI_Learning_1.Data.Users;

namespace WebAPI_Learning_1.Requests.Queries
{
    public class GetUsersQuery : IRequest<IQueryable<User>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IQueryable<User>>
    {
        private readonly UserRepository _userRepo;

        public GetUsersQueryHandler(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public IQueryable<User> Handle(GetUsersQuery message)
        {
            return _userRepo.GetAll();
        }
    }
}