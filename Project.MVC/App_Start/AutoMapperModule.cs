﻿using AutoMapper;
using Ninject;
using Ninject.Modules;
using Project.MVC.Models;
using Project.Service.ServiceModels;

namespace Project.MVC.App_Start
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            Bind<IMapper>().ToMethod(ctx =>
                 new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehicleMake, VehicleMakeView>().ReverseMap();
                cfg.CreateMap<VehicleModel, VehicleModelView>().ReverseMap();
            });

            config.AssertConfigurationIsValid();

            return config;
        }
    }
}