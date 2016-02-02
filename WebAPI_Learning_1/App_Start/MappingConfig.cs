using AutoMapper;
using WebAPI_Learning_1.Data.Users;
using WebAPI_Learning_1.Requests.Users;

namespace WebAPI_Learning_1
{
    public class MappingConfig
    {
        public static IMapper Register()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateUserCommand, User>();
                cfg.CreateMap<UpdateUserCommand, User>()
                .ForMember(dest => dest.CreatedAt, opts => opts.Ignore());
            });

            Instance = config.CreateMapper();

            return Instance;
        }

        public static IMapper Instance { get; set; }
    }
}