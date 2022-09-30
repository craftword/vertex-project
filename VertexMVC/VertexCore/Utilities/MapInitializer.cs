using System;
using AutoMapper;
using VertexCore.Models;
using VertexCore.ViewModels;

namespace VertexCore.Utilities
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
        }

    }
}
