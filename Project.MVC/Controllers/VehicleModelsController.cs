using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Project.MVC.Models;
using Project.Service.VehicleService;
using Project.Service.ServiceModels;
using System.Collections.Generic;
using PagedList;
using Project.MVC.Models.PagedViewModel;

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
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sort) ? "Name_desc" : "";
            ViewBag.SortAbrvParameter = sort == "Abrv" ? "Abrv_desc" : "Abrv";

            var vehicleModel = await _vehicleServiceModel.GetAllAsync();

            if (!string.IsNullOrEmpty(expression))
            {
                vehicleModel = await _vehicleServiceModel.FindAllAsync
                    (expression);
            }
            else
            {
                vehicleModel = await _vehicleServiceModel.OrderByAsync(sort);
            }

            var paging = _vehicleServiceModel.PaginationAsync(page);
            var vehicleMapped = _mapper.Map<PagedViewModel<VehicleModelView>>(vehicleModel);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Details/5
        public async Task <ActionResult> Details(int? id)
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

            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public async Task <ActionResult> Create()
        {
            var model = await _vehicleServiceMake.GetAllAsync();
            ViewBag.MakeId = new SelectList(model, "Id", "Name");
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

            var model = await _vehicleServiceMake.GetAllAsync();
            ViewBag.MakeId = new SelectList(model, "Id", "Name", vehicleModel.MakeId);
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
            var model = await _vehicleServiceMake.GetAllAsync();
            ViewBag.MakeId = new SelectList(model, "Id", "Name", vehicleModel.MakeId);
            return View(vehicleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleServiceModel.UpdateAsync(vehicleModel);
                var vehicleMapped = _mapper.Map<VehicleModelView>(vehicleModel);
                return RedirectToAction("Index", "VehicleModels");
            }

            var model = await _vehicleServiceMake.GetAllAsync();
            ViewBag.MakeId = new SelectList(model, "Id", "Name", vehicleModel.MakeId);
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
            return View(vehicleModel);
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
