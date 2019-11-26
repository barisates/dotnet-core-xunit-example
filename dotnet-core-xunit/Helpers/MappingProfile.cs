using AutoMapper;
using dotnet_core_xunit.Dtos;
using dotnet_core_xunit.Entities.TestDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_xunit.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UserDto.User>();
            CreateMap<UserDto.User, Users >();
        }
    }
}
