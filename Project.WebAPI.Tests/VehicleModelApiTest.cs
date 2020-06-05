using AutoMapper;
using FluentAssertions;
using Moq;
using Project.Model;
using Project.Service.Common;
using Project.WebAPI.Controllers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Xunit;

namespace Project.WebAPI.Tests
{
    public class VehicleModelApiTest
    {
        VehicleModel vehicleModel = new VehicleModel
        { Id = 1, Name = "BMW", Abrv = "i8", MakeId = 1 };

        Mock<IVehicleServiceModel> vehicleServiceModel = new Mock<IVehicleServiceModel>();
        private IVehicleServiceMake _vehicleServiceMake;
        private readonly IMapper _mapper;
        int modelId = 1;

        [Fact]
        public async Task GetById()
        {
            var vehicleModelController = new VehicleModelsController(vehicleServiceModel.Object, _vehicleServiceMake, _mapper);
            await vehicleModelController.GetVehicleModel(modelId);

            vehicleServiceModel.Should().NotBeNull();
            vehicleServiceModel.Should().Equals(modelId);
        }

        [Fact]
        public async Task PostsLocation()
        {
            var vehicleModelController = new VehicleModelsController(vehicleServiceModel.Object, _vehicleServiceMake, _mapper);
            var config = new HttpConfiguration();

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/");

            IHttpRoute route = config.Routes.MapHttpRoute("DefaultApi","api/{controller}/{id}");

            HttpRouteData routeData = new HttpRouteData(route, new HttpRouteValueDictionary
            {
                { "controller", "posts" }
            });

            vehicleModelController.ControllerContext = new HttpControllerContext(config, routeData, request);

            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;

            vehicleModelController.Request = request;

            VehicleModel vehicleModel = new VehicleModel() { Id = modelId };

            vehicleServiceModel.Should().Equals(HttpStatusCode.Created);
            vehicleServiceModel.Should().NotBeNull();
        }
    }
}
