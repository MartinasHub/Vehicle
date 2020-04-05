using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Project.MVC.Models;
using Project.Service.VehicleService;
using Project.Service.ServiceModels;
using System.Collections.Generic;
using Project.MVC.SearchSortPage;
using System;

namespace Project.MVC.Controllers
{
    public class VehicleModelsController : Controller
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

        // GET: VehicleModels
        public async Task<ActionResult> Index(string expression, string sort, int? page)
        {
            ViewBag.SortNameParameter = String.IsNullOrEmpty(sort) ? "Name_desc" : "";
            ViewBag.SortAbrvParameter = sort == "Abrv" ? "Abrv_desc" : "Abrv";

            var vehicleModel = await _vehicleServiceModel.GetAllAsync();

            Searching searching = new Searching();
            await _vehicleServiceModel.FindAllAsync(searching.expression);
            Sorting sorting = new Sorting();
            await _vehicleServiceModel.OrderByAsync(sorting.sort);
            Paging paging = new Paging();
            await _vehicleServiceModel.PaginationAsync(paging.page);

            var vehicleMapped = _mapper.Map<IEnumerable<VehicleModelView>>(vehicleModel);
            return View(vehicleMapped);
        }

        // GET: VehicleModels/Details/5
        public async Task <ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VehicleModel vehicleModel = await _vehicleServiceModel.GetByIdAsync(id.Value);
            var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);

            if (vehicleModel == null)
            {
                return HttpNotFound();
            }

            return View(vehicleMapped);
        }

        // GET: VehicleModels/Create
        public async Task <ActionResult> Create()
        { 
            ViewBag.MakeId = new SelectList(await _vehicleServiceMake.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleServiceModel.InsertAsync(vehicleModel);
                var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);
                return RedirectToAction("Index", "VehicleModels");
            }

            ViewBag.MakeId = new SelectList(await _vehicleServiceMake.GetAllAsync(), "Id", "Name", vehicleModel.MakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public async Task <ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VehicleModel vehicleModel = await _vehicleServiceModel.GetByIdAsync(id.Value);

            if (vehicleModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.MakeId = new SelectList(await _vehicleServiceMake.GetAllAsync(), "Id", "Name", vehicleModel.MakeId);
            var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);
            return View(vehicleMapped);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleServiceModel.UpdateAsync(vehicleModel);
                return RedirectToAction("Index", "VehicleModels");
            }

            ViewBag.MakeId = new SelectList(await _vehicleServiceMake.GetAllAsync(), "Id", "Name", vehicleModel.MakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public async Task <ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VehicleModel vehicleModel = await _vehicleServiceModel.GetByIdAsync(id.Value);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);
            return View(vehicleMapped);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> DeleteConfirmed(int id)
        {
            VehicleModel vehicleModel = await _vehicleServiceModel.GetByIdAsync(id);
            await _vehicleServiceModel.DeleteAsync(id);
            return RedirectToAction("Index", "VehicleModels");
        }
    }
}
