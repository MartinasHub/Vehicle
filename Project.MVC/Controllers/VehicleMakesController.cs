using System.Threading.Tasks;
using Project.MVC.Models;
using Project.Service.VehicleService;
using AutoMapper;
using Project.Service.ServiceModels;
using System.Collections.Generic;
using Project.MVC.SearchSortPage;
using System;
using System.Web.Http;

namespace Project.MVC.Controllers
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
        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string search, string sortOrder, int? page)
        {
            //ViewBag.SortNameParameter = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            //ViewBag.SortAbrvParameter = sortOrder == "Abrv" ? "Abrv_desc" : "Abrv";

            Searching searching = new Searching();
            Sorting sorting = new Sorting();
            Paging paging = new Paging();
            searching.Search = search;
            sorting.SortOrder = sortOrder;
            paging.Page = page;

            var vehicleMapped = _mapper.Map<IEnumerable<VehicleMakeView>>(await _vehicleServiceMake.GetAllAsync(search, sortOrder, page));
            return Ok(vehicleMapped);
        }

        [HttpGet]
        //GET /api/VehicleMakes/1
        public async Task<IHttpActionResult> Get(int id)
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
