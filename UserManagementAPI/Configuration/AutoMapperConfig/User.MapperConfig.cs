using AutoMapper;
using UserManagementAPI.Models;
using UserManagementAPI.Models.Binding;
using UserManagementAPI.Models.View;

namespace UserManagementAPI.Configuration.AutoMapperConfig
{
    public class UsersMapperConfig
    {
        public static void RegisterMappings(IMapperConfigurationExpression mapperConfig)
        {
            mapperConfig.CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opts => opts.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Nationality, opts => opts.MapFrom(src => src.Nationality))
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.Role));

            mapperConfig.CreateMap<User, UserBindingModel>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opts => opts.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Nationality, opts => opts.MapFrom(src => src.Nationality))
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.Role));
        }

    }
}
