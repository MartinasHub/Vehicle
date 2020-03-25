using AutoMapper;
using Project.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleMake, VehicleMakeView>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelView>().ReverseMap();
        }
    }
}