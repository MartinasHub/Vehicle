using AutoMapper;
using Project.Model;
using Project.Common.SearchSortPage;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Project.Repository;

namespace Project.WebAPI.Controllers
{
    public class VehicleModelsController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;

        public VehicleModelsController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        // GET /api/VehicleModels
        public async Task<IHttpActionResult> Get(string search, string sortOrder, int? page)
        {
            Searching searching = new Searching();
            Sorting sorting = new Sorting();
            Paging paging = new Paging();
            searching.Search = search;
            sorting.SortOrder = sortOrder;
            paging.Page = page;

            var vehicleMapped = _mapper.Map<IEnumerable<VehicleModelView>>(await _unitOfWork.VehicleModelRepository.GetAllAsync(search, sortOrder, page));
            return Ok(vehicleMapped);
        }

        [HttpGet]
        //GET /api/VehicleModels/1
        public async Task<IHttpActionResult> GetVehicleModel(int id)
        {
            var vehicleModel = await _unitOfWork.VehicleModelRepository.GetByIdAsync(id);

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
            await _unitOfWork.VehicleModelRepository.InsertAsync(vehicleModel);

            return Created(new Uri(Request.RequestUri + "/" + vehicleModel.Id), vehicleModel);
        }

        // PUT /api/VehicleModels/1
        [HttpPut]
        public async Task<IHttpActionResult> Edit(int id, VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _unitOfWork.VehicleModelRepository.UpdateAsync(vehicleModel);

            if (vehicleModel == null)
                return NotFound();

            var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);
            return Ok(vehicleMapped);
        }

        // DELETE /api/VehicleModels/1
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            VehicleModel vehicleModel = await _unitOfWork.VehicleModelRepository.GetByIdAsync(id);

            if (vehicleModel == null)
                return NotFound();

            await _unitOfWork.VehicleMakeRepository.DeleteAsync(id);

            var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);

            return Ok(vehicleMapped);
        }
    }
}
