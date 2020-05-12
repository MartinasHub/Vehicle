using FluentAssertions;
using Moq;
using Project.Model;
using Project.Service.Common;
using System.Threading.Tasks;
using Xunit;

namespace Project.Service.Tests
{
    public class VehicleModelTest
    {
        VehicleModel vehicleModel = new VehicleModel
        { Id = 4, MakeId = 1, Name = "X6", Abrv = "BMW" };
        private Mock<IVehicleServiceModel> mockVehicleServiceModel = new Mock<IVehicleServiceModel>();

        string search;
        string sortOrder;
        int? page;
        int modelId = 4;

        [Fact]
        public async Task GetAllVehicleModel()
        {
            mockVehicleServiceModel.Setup(x => x.GetAllAsync(search, sortOrder, page));
            await mockVehicleServiceModel.Object.GetAllAsync(search, sortOrder, page);

            vehicleModel.Should().NotBeNull();
            vehicleModel.Should().Equals(modelId);
            mockVehicleServiceModel.Verify(x => x.GetAllAsync(search, sortOrder, page), Times.Once);
        }

        [Fact]
        public async Task AddVehicleModel()
        {
            mockVehicleServiceModel.Setup(x => x.InsertAsync(vehicleModel));
            await mockVehicleServiceModel.Object.InsertAsync(vehicleModel);

            vehicleModel.Should().NotBeNull();
            vehicleModel.Should().BeOfType(typeof(VehicleModel));
            mockVehicleServiceModel.Verify(x => x.InsertAsync(vehicleModel), Times.Once);
        }

        [Fact]
        public async Task GetByIdVehicleModel()
        {
            mockVehicleServiceModel.Setup(x => x.GetByIdAsync(modelId)).ReturnsAsync(vehicleModel);
            await mockVehicleServiceModel.Object.GetByIdAsync(modelId);
            mockVehicleServiceModel.Verify(x => x.GetByIdAsync(vehicleModel.Id), Times.Once());

            vehicleModel.Should().BeSameAs(vehicleModel);
            vehicleModel.Should().BeOfType(typeof(VehicleModel));
        }

        [Fact]
        public async Task DeleteVehicleModel()
        {
            mockVehicleServiceModel.Setup(x => x.DeleteAsync(modelId));
            await mockVehicleServiceModel.Object.DeleteAsync(modelId);

            mockVehicleServiceModel.Setup(x => x.GetByIdAsync(modelId));
            mockVehicleServiceModel.Object.GetByIdAsync(modelId).Should().NotBe(null);

            mockVehicleServiceModel.Verify(x => x.DeleteAsync(modelId), Times.Once);
        }

        [Fact]
        public async Task UpdateVehicleModel()
        {
            mockVehicleServiceModel.Setup(x => x.GetByIdAsync(modelId));
            await mockVehicleServiceModel.Object.GetByIdAsync(modelId);

            mockVehicleServiceModel.Setup(x => x.InsertAsync(vehicleModel));
            await mockVehicleServiceModel.Object.InsertAsync(vehicleModel);

            mockVehicleServiceModel.Verify(x => x.GetByIdAsync(modelId), Times.Once);

            vehicleModel.Should().NotBeNull();
        }
    }
}
