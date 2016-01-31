using System.Threading.Tasks;
using MediatR;
using WebAPI_Learning_1.Data;
using WebAPI_Learning_1.Interfaces;

namespace WebAPI_Learning_1.Requests.Queries
{
    public class GetByIdQuery<T>: IAsyncRequest<T> where T : IEntity
    {
        public long Id { get; set; }
    }

    public class GetByIdQueryHandler<T> : IAsyncRequestHandler<GetByIdQuery<T>, T> where T : class, IEntity
    {
        private readonly BaseRepository<T> _repo;

        public GetByIdQueryHandler(BaseRepository<T> repo)
        {
            _repo = repo;
        }

        public Task<T> Handle(GetByIdQuery<T> message)
        {
            return _repo.GetByIdAsync(message.Id);
        }
    }
}