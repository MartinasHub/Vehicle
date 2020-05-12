using AutoMapper;
using Project.Common.SearchSortPage;
using Project.Model;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    public class VehicleMakesController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;

        public VehicleMakesController(UnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        // GET /api/VehicleMakes
        [HttpGet]
        public async Task<IHttpActionResult> Get(string search, string sortOrder, int? page)
        {
            Searching searching = new Searching();
            Sorting sorting = new Sorting();
            Paging paging = new Paging();
            searching.Search = search;
            sorting.SortOrder = sortOrder;
            paging.Page = page;

            var vehicleMapped = _mapper.Map<IEnumerable<VehicleMakeView>>(await _unitOfWork.VehicleMakeRepository.GetAllAsync(search, sortOrder, page));
            return Ok(vehicleMapped);
        }

        [HttpGet]
        //GET /api/VehicleMakes/1
        public async Task<IHttpActionResult> GetVehicleMake(int id)
        {
            var vehicleMake = await _unitOfWork.VehicleMakeRepository.GetByIdAsync(id);

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
            await _unitOfWork.VehicleMakeRepository.InsertAsync(vehicleMake);

            return Created(new Uri(Request.RequestUri + "/" + vehicleMake.Id), vehicleMake);
        }

        // PUT /api/VehicleMakes/1
        [HttpPut]
        public async Task<IHttpActionResult> Edit(int id, VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _unitOfWork.VehicleMakeRepository.UpdateAsync(vehicleMake);

            if (vehicleMake == null)
                return NotFound();
            var vehicleMapped = _mapper.Map<VehicleMakeView>(vehicleMake);

            return Ok(vehicleMapped);
        }

        // DELETE /api/VehicleMakes/1
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            VehicleMake vehicleMake = await _unitOfWork.VehicleMakeRepository.GetByIdAsync(id);

            if (vehicleMake == null)
                return NotFound();

            await _unitOfWork.VehicleMakeRepository.DeleteAsync(id);

            var vehicleMapped = _mapper.Map<VehicleMakeView>(vehicleMake);

            return Ok(vehicleMapped);
        }
    }
}
