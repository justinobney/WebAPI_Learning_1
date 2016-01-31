using AutoMapper;
using WebAPI_Learning_1.Data.Users;
using WebAPI_Learning_1.Requests.Commands;

namespace WebAPI_Learning_1
{
    public class MappingConfig
    {
        public static IMapper Register()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateUserCommand, User>();
            });

            Instance = config.CreateMapper();

            return Instance;
        }

        public static IMapper Instance { get; set; }
    }
}