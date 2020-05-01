using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Project.MVC.Models;
using Project.Service.VehicleService;
using AutoMapper;
using Project.Service.ServiceModels;
using System.Collections.Generic;
using Project.MVC.SearchSortPage;
using System;

namespace Project.MVC.Controllers
{
    public class VehicleMakesController : Controller
    {
        private IVehicleServiceMake _vehicleServiceMake;
        private readonly IMapper _mapper;

        public VehicleMakesController(IVehicleServiceMake vehicleServiceMake, IMapper mapper)
        {
            this._vehicleServiceMake = vehicleServiceMake;
            this._mapper = mapper;
        }

        // GET: VehicleMakes
        public async Task<ActionResult> Index(string search, string sortOrder, int? page)
        {
            ViewBag.SortNameParameter = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.SortAbrvParameter = sortOrder == "Abrv" ? "Abrv_desc" : "Abrv";

            Searching searching = new Searching();
            Sorting sorting = new Sorting();
            Paging paging = new Paging();
            searching.Search = search;
            sorting.SortOrder = sortOrder;
            paging.Page = page;

            var vehicleMapped = _mapper.Map<IEnumerable<VehicleMakeView>>(await _vehicleServiceMake.GetAllAsync(search, sortOrder, page));
            return View(vehicleMapped);
        }

        // GET: VehicleMakes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VehicleMake vehicleMake = await _vehicleServiceMake.GetByIdAsync(id.Value);
            var vehicleMapped = _mapper.Map<VehicleMakeView>(vehicleMake);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMapped);
        }

        // GET: VehicleMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                await _vehicleServiceMake.InsertAsync(vehicleMake);
                var vehicleMapped = _mapper.Map<VehicleMakeView>(vehicleMake);
                return RedirectToAction("Index", "VehicleMakes");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VehicleMake vehicleMake = await _vehicleServiceMake.GetByIdAsync(id.Value);
            var vehicleMapped = _mapper.Map<VehicleMakeView>(vehicleMake);

            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMapped);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                await _vehicleServiceMake.UpdateAsync(vehicleMake);
                return RedirectToAction("Index", "VehicleMakes");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VehicleMake vehicleMake = await _vehicleServiceMake.GetByIdAsync(id.Value);

            if (vehicleMake == null)
            {
                return HttpNotFound();
            }

            var vehicleMapped = _mapper.Map<VehicleMakeView>(vehicleMake);
            return View(vehicleMapped);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehicleMake vehicleMake = await _vehicleServiceMake.GetByIdAsync(id);
            await _vehicleServiceMake.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
