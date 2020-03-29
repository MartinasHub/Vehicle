using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Project.MVC.Models;
using Project.Service.VehicleService;
using PagedList;
using AutoMapper;

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
        public async Task<ActionResult> Index(string expression, string sort, int? page)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sort) ? "Name_desc" : "";
            ViewBag.SortAbrvParameter = sort == "Abrv" ? "Abrv_desc" : "Abrv";

            var vehicleMake = await _vehicleServiceMake.GetAllAsync();

            if (!string.IsNullOrEmpty(expression))
            {
                vehicleMake = await _vehicleServiceMake.FindAllAsync(expression);
            }
            else
            {
                vehicleMake = await _vehicleServiceMake.OrderByAsync(sort);
            }

            var vehicleMapped =_mapper.Map<VehicleMakeView>(vehicleMake);
            return View(vehicleMake.ToPagedList(page ?? 1, 10));
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
                var vehicleMapped = _mapper.Map<VehicleMakeView>(vehicleMake);
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
