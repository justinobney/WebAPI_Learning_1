using WebAPI_Learning_1.Models;

namespace WebAPI_Learning_1.Data
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(WebAPI_Learning_1Context context) : base(context)
        {
        }
    }
}