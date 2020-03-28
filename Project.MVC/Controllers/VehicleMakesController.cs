using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Project.MVC.Models;
using Project.Service.VehicleService;
using System.Linq;
using PagedList;
using PagedList.Mvc;

namespace Project.MVC.Controllers
{
    public class VehicleMakesController : Controller
    {
        private IVehicleServiceMake _vehicleServiceMake;

        public VehicleMakesController(IVehicleServiceMake vehicleServiceMake)
        {
            this._vehicleServiceMake = vehicleServiceMake;
        }

        // GET: VehicleMakes
        public async Task<ActionResult> Index(string expression, string sort, int? page)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sort) ? "Name_desc" : "";
            ViewBag.SortAbrvParameter = sort == "Abrv" ? "Abrv_desc" : "Abrv";

            var model = await _vehicleServiceMake.GetAllAsync();

            model = await _vehicleServiceMake.FindAllAsync(expression);

            model = await _vehicleServiceMake.OrderByAsync(sort);

            return View(model.ToPagedList(page ?? 1, 10));
        }

        // GET: VehicleMakes/Details/5
        public async Task<ActionResult> Details(int? id)
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
            return View(vehicleMake);
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

            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
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
            return View(vehicleMake);
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
