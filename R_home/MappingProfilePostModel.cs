using AutoMapper;
using R_home.Core.Models;
using R_home.Models;
using System.Data;

namespace R_home
{
    public class MappingProfilePostModel:Profile
    {
        public MappingProfilePostModel()
        {
            CreateMap<BabyPostModel, Baby>().ReverseMap();
            CreateMap<EmployeePostModel, Employee>().ReverseMap();
            CreateMap<RoomPostModel, Room>().ReverseMap();
        }
    }
}
