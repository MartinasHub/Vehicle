using AutoMapper;
using Project.Common.SearchSortPage;
using Project.Model;
using Project.Service.Common;
using Project.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    public class VehicleMakesController : ApiController
    {
        private IVehicleServiceMake _vehicleServiceMake;
        private readonly IMapper _mapper;

        public VehicleMakesController(IVehicleServiceMake vehicleServiceMake, IMapper mapper)
        {
            this._vehicleServiceMake = vehicleServiceMake;
            this._mapper = mapper;
        }

        // GET /api/VehicleMakes
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri]SearchingSortingPaging searchingSortingPaging)
        {
            string search = searchingSortingPaging.Search;
            string sortOrder = searchingSortingPaging.SortOrder;
            int? page = searchingSortingPaging.Page;

            var vehicleMapped = _mapper.Map<IEnumerable<VehicleMakeView>>(await _vehicleServiceMake.GetAllAsync(search, sortOrder, page));
            return Ok(vehicleMapped);
        }

        [HttpGet]
        //GET /api/VehicleMakes/1
        public async Task<IHttpActionResult> GetVehicleMake(int id)
        {
            var vehicleMake = await _vehicleServiceMake.GetByIdAsync(id);

            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VehicleMakeView>(vehicleMake));
        }

        // POST /api/VehicleMakes
        [HttpPost]
        public async Task<IHttpActionResult> Create(VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var vehicleMapped = _mapper.Map<VehicleMakeView>(vehicleMake);
            await _vehicleServiceMake.InsertAsync(vehicleMake);

            return Created(new Uri(Request.RequestUri + "/" + vehicleMake.Id), vehicleMake);
        }

        // PUT /api/VehicleMakes/1
        [HttpPut]
        public async Task<IHttpActionResult> Edit(int id, VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _vehicleServiceMake.UpdateAsync(vehicleMake);

            if (vehicleMake == null)
                return NotFound();
            var vehicleMapped = _mapper.Map<VehicleMakeView>(vehicleMake);

            return Ok(vehicleMapped);
        }

        // DELETE /api/VehicleMakes/1
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            VehicleMake vehicleMake = await _vehicleServiceMake.GetByIdAsync(id);

            if (vehicleMake == null)
                return NotFound();

            await _vehicleServiceMake.DeleteAsync(id);

            var vehicleMapped = _mapper.Map<VehicleMakeView>(vehicleMake);

            return Ok(vehicleMapped);
        }
    }
}
