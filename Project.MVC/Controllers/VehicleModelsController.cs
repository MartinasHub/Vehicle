using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using Project.MVC.Models;
using Project.Service.VehicleService;

namespace Project.MVC.Controllers
{
    public class VehicleModelsController : Controller
    {
        private IVehicleServiceModel _vehicleServiceModel;
        private IVehicleServiceMake _vehicleServiceMake;

        public VehicleModelsController(IVehicleServiceModel vehicleServiceModel, IVehicleServiceMake vehicleServiceMake)
        {
            this._vehicleServiceModel = vehicleServiceModel;
            this._vehicleServiceMake = vehicleServiceMake;
        }

        // GET: VehicleModels
        public async Task <ActionResult> Index(string expression, string sort, int? page)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sort) ? "Name_desc" : "";
            ViewBag.SortAbrvParameter = sort == "Abrv" ? "Abrv_desc" : "Abrv";

            var model = await _vehicleServiceModel.GetAllAsync();

            model = await _vehicleServiceModel.FindAllAsync
                (x => x.VehicleMakes.Name == expression || expression == null);

            switch (sort)
            {
                case "Name_desc":
                    model = model.OrderByDescending(m => m.Name);
                    break;
                case "Abrv":
                    model = model.OrderBy(m => m.Abrv);
                    break;
                case "Abrv_desc":
                    model = model.OrderByDescending(m => m.Abrv);
                    break;
                default:
                case "Name":
                    model = model.OrderBy(m => m.Name);
                    break;
            }
            return View(model.ToPagedList(page ?? 1, 10));
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
