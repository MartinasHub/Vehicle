using AutoMapper;
using Project.Model;
using Project.MVC.Models;
using Project.MVC.SearchSortPage;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    public class VehicleModelsController : ApiController
    {
        private IVehicleServiceModel _vehicleServiceModel;
        private IVehicleServiceMake _vehicleServiceMake;
        private readonly IMapper _mapper;

        public VehicleModelsController(IVehicleServiceModel vehicleServiceModel, IVehicleServiceMake vehicleServiceMake,
            IMapper mapper)
        {
            this._vehicleServiceModel = vehicleServiceModel;
            this._vehicleServiceMake = vehicleServiceMake;
            this._mapper = mapper;
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        // GET /api/VehicleModels
        public async Task<IHttpActionResult> Index(string search, string sortOrder, int? page)
        {
            Searching searching = new Searching();
            Sorting sorting = new Sorting();
            Paging paging = new Paging();
            searching.Search = search;
            sorting.SortOrder = sortOrder;
            paging.Page = page;

            var vehicleMapped = _mapper.Map<IEnumerable<VehicleModelView>>(await _vehicleServiceModel.GetAllAsync(search, sortOrder, page));
            return Ok(vehicleMapped);
        }

        [HttpGet]
        //GET /api/VehicleModels/1
        public async Task<IHttpActionResult> Get(int id)
        {
            var vehicleModel = await _vehicleServiceModel.GetByIdAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VehicleMakeView>(vehicleModel));
        }

        // POST /api/VehicleModels
        [HttpPost]
        public async Task<IHttpActionResult> Create(VehicleModel vehicleModel, string search, string sortOrder, int? page)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);
            await _vehicleServiceModel.InsertAsync(vehicleModel);

            Searching searching = new Searching();
            Sorting sorting = new Sorting();
            Paging paging = new Paging();
            searching.Search = search;
            sorting.SortOrder = sortOrder;
            paging.Page = page;
            //ViewBag.MakeId = new SelectList(await _vehicleServiceMake.GetAllAsync(search, sortOrder, page), "Id", "Name", vehicleModel.MakeId);

            return Created(new Uri(Request.RequestUri + "/" + vehicleModel.Id), vehicleModel);
        }

        // PUT /api/VehicleModels/1
        [HttpPut]
        public async Task<IHttpActionResult> Edit(int id, VehicleModel vehicleModel, string sortOrder, string search, int? page)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _vehicleServiceModel.UpdateAsync(vehicleModel);

            if (vehicleModel == null)
                return NotFound();

            Searching searching = new Searching();
            Sorting sorting = new Sorting();
            Paging paging = new Paging();
            searching.Search = search;
            sorting.SortOrder = sortOrder;
            paging.Page = page;
            //ViewBag.MakeId = new SelectList(await _vehicleServiceMake.GetAllAsync(search, sortOrder, page), "Id", "Name", vehicleModel.MakeId);
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
