using AutoMapper;
using Ninject;
using Ninject.Modules;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
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
                cfg.CreateMap<VehicleMake, VehicleMakeView>()
                .ForMember(m => m.VehicleModels, m => m.Ignore())
                .ReverseMap();
                cfg.CreateMap<VehicleModel, VehicleModelView>()
                .ForMember(m => m.MakeId, m => m.MapFrom(map => map.VehicleMakes.Id))
                .ReverseMap();
            });

            config.AssertConfigurationIsValid();

            return config;
        }
    }
}