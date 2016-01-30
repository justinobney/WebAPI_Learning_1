namespace WebAPI_Learning_1.Data.Users
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(WebAPI_Learning_1Context context) : base(context)
        {
        }
    }
}