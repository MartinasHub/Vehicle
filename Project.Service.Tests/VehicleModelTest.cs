using FluentAssertions;
using Moq;
using Project.Model;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project.Service.Tests
{
    public class VehicleModelTest
    {
        VehicleModel vehicleModel = new VehicleModel
        { Id = 4, MakeId = 1, Name = "X6", Abrv = "BMW" };
        private Mock<IRepository<VehicleModel>> mockRepository = new Mock<IRepository<VehicleModel>>();

        string search;
        string sortOrder;
        int? page;
        int modelId = 4;

        [Fact]
        public async Task GetAllVehicleModel()
        {
            mockRepository.Setup(x => x.GetAllAsync(search, sortOrder, page));
            await mockRepository.Object.GetAllAsync(search, sortOrder, page);

            vehicleModel.Should().NotBeNull();
            vehicleModel.Should().Equals(modelId);
            mockRepository.Verify(x => x.GetAllAsync(search, sortOrder, page), Times.Once);
        }

        [Fact]
        public async Task AddVehicleModel()
        {
            mockRepository.Setup(x => x.InsertAsync(vehicleModel));
            await mockRepository.Object.InsertAsync(vehicleModel);

            vehicleModel.Should().NotBeNull();
            vehicleModel.Should().BeOfType(typeof(VehicleModel));
            mockRepository.Verify(x => x.InsertAsync(vehicleModel), Times.Once);
        }

        [Fact]
        public async Task GetByIdVehicleModel()
        {
            mockRepository.Setup(x => x.GetByIdAsync(modelId)).ReturnsAsync(vehicleModel);
            await mockRepository.Object.GetByIdAsync(modelId);
            mockRepository.Verify(x => x.GetByIdAsync(vehicleModel.Id), Times.Once());

            vehicleModel.Should().BeSameAs(vehicleModel);
            vehicleModel.Should().BeOfType(typeof(VehicleModel));
        }

        [Fact]
        public async Task DeleteVehicleModel()
        {
            mockRepository.Setup(x => x.DeleteAsync(modelId));
            await mockRepository.Object.DeleteAsync(modelId); 

            mockRepository.Setup(x => x.GetByIdAsync(modelId));
            mockRepository.Object.GetByIdAsync(modelId).Should().NotBe(null); 

            mockRepository.Verify(x => x.DeleteAsync(modelId), Times.Once);
        }

        [Fact]
        public async Task UpdateVehicleModel()
        {
            mockRepository.Setup(x => x.GetByIdAsync(modelId));
            await mockRepository.Object.GetByIdAsync(modelId);

            mockRepository.Setup(x => x.InsertAsync(vehicleModel));
            await mockRepository.Object.InsertAsync(vehicleModel);

            mockRepository.Verify(x => x.GetByIdAsync(modelId), Times.Once);

            vehicleModel.Should().NotBeNull();
        }
    }
}
