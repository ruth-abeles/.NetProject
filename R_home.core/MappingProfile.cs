using AutoMapper;
using R_home.Core.DTOs;
using R_home.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_home.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Baby, BabyDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
        }
    }
}
