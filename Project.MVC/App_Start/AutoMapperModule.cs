using AutoMapper;
using Ninject;
using Ninject.Modules;
using PagedList;
using Project.MVC.Models;
using Project.MVC.Models.PagedViewModel;
using Project.Service.ServiceModels;
using System;

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
                cfg.CreateMap(typeof(IPagedList<>), typeof(PagedViewModel<>)).ConvertUsing(typeof(Converter<,>));
            });

            config.AssertConfigurationIsValid();

            return config;
        }
    }
}