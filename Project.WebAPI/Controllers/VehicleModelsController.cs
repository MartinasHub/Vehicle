using AutoMapper;
using Project.Model;
using Project.Common.SearchSortPage;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Project.Repository;
using Project.WebAPI.Models;

namespace Project.WebAPI.Controllers
{
    public class VehicleModelsController : ApiController
    {
        private IVehicleServiceModel _vehicleServiceModel;
        private IVehicleServiceMake _vehicleServiceMake;
        private readonly IMapper _mapper;

        public VehicleModelsController(IVehicleServiceModel vehicleServiceModel, IVehicleServiceMake vehicleServiceMake, IMapper mapper)
        {
            this._vehicleServiceModel = vehicleServiceModel;
            this._vehicleServiceMake = vehicleServiceMake;
            this._mapper = mapper;
        }

        [HttpGet]
        // GET /api/VehicleModels
        public async Task<IHttpActionResult> Get([FromUri]SearchingSortingPaging searchingSortingPaging)
        {
            string search = searchingSortingPaging.Search;
            string sortOrder = searchingSortingPaging.SortOrder;
            int? page = searchingSortingPaging.Page;

            var vehicleMapped = _mapper.Map<IEnumerable<VehicleModelView>>(await _vehicleServiceModel.GetAllAsync(search, sortOrder, page));
            return Ok(vehicleMapped);
        }

        [HttpGet]
        //GET /api/VehicleModels/1
        public async Task<IHttpActionResult> GetVehicleModel(int id)
        {
            var vehicleModel = await _vehicleServiceModel.GetByIdAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VehicleModelView>(vehicleModel));
        }

        // POST /api/VehicleModels
        [HttpPost]
        public async Task<IHttpActionResult> Create(VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);
            await _vehicleServiceModel.InsertAsync(vehicleModel);

            return Created(new Uri(Request.RequestUri + "/" + vehicleModel.Id), vehicleModel);
        }

        // PUT /api/VehicleModels/1
        [HttpPut]
        public async Task<IHttpActionResult> Edit(int id, VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _vehicleServiceModel.UpdateAsync(vehicleModel);

            if (vehicleModel == null)
                return NotFound();

            var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);
            return Ok(vehicleMapped);
        }

        // DELETE /api/VehicleModels/1
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            VehicleModel vehicleModel = await _vehicleServiceModel.GetByIdAsync(id);

            if (vehicleModel == null)
                return NotFound();

            await _vehicleServiceMake.DeleteAsync(id);

            var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);

            return Ok(vehicleMapped);
        }
    }
}
