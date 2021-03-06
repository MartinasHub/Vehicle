﻿using Project.Model;
using Project.Repository.Common;
using Project.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleServiceModel : IVehicleServiceModel
    {
        private IRepository<VehicleModel> _repository;

        public VehicleServiceModel(IRepository<VehicleModel> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<VehicleModel>> GetAllAsync(string search, string sortOrder, int? page)
        {
            return await _repository.GetAllAsync(search, sortOrder, page);
        }

        public async Task<VehicleModel> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(VehicleModel vehicleModel)
        {
            await _repository.InsertAsync(vehicleModel);
        }

        public async Task UpdateAsync(VehicleModel vehicleModel)
        {
            await _repository.UpdateAsync(vehicleModel);
        }
    }
}
