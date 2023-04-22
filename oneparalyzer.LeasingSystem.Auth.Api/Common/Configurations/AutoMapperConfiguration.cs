using AutoMapper;
using oneparalyzer.LeasingSystem.Auth.Api.Contracts.Responses;
using oneparalyzer.LeasingSystem.Auth.Api.Entities;

namespace oneparalyzer.LeasingSystem.Auth.Api.Common.Configurations;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<User, GetAllUsersResponse>()
            .ForPath(dst => dst.RolesTitle, opt => opt.MapFrom(src => src.Roles.Select(x => x.Title)));

        CreateMap<User, GetByIdUserResponse>();
    }
}
