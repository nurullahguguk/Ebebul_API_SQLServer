using AutoMapper;
using Ebebul.Core.DTOs;
using Ebebul.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //CreateMap<User, UserDto>(); => User'ı UserDto'ya çevirir.
            //CreateMap<User, UserDto>().ReverseMap(); => User'ı UserDto'ya , UserDto'yu User'a çevirir.
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<UserUpdateDto, User>();
        }

    }
}
