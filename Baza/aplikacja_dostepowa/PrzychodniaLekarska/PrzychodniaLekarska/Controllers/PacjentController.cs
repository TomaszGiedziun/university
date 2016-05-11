using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrzychodniaLekarska.Models;

namespace PrzychodniaLekarska.Controllers
{
    public class PacjentController : Controller
    {
        // GET: Pacjent
        public ActionResult Index()
        {
            List<PacjentModel> pacjentList = new List<PacjentModel>();
            IPacjentService service = new PacjentService();

            pacjentList = service.GetAllPacjent();

            return View(pacjentList);
        }

        public ActionResult Create()
        {
            return View();
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PacjentModel pacjent)
        {
            if (ModelState.IsValid)
            {
                IPacjentService service = new PacjentService();
                service.AddPacjent(pacjent);

                return RedirectToAction("Index");
            }

            return View(pacjent);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPacjentService service = new PacjentService();
            service.DeletePacjentById(id.Value);

            return RedirectToAction("Index");
        }

        // Called from Index (only id) or Edit (id and delete) view
        public ActionResult Edit(int? id, bool? delete)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IPacjentService service = new PacjentService();
            PacjentModel pacjent = new PacjentModel();
            pacjent = service.GetPacjentById(id.Value);

            if (pacjent == null)
            {
                return HttpNotFound();
            }

            if (delete.HasValue)
            {
                service.DeletePacjent(pacjent);
                return RedirectToAction("Index");
            }

            return View(pacjent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PacjentModel pacjent)
        {
            if (ModelState.IsValid)
            {
                IPacjentService service = new PacjentService();
                service.EditPacjent(pacjent);

                return RedirectToAction("Index");
            }

            return View(pacjent);
        }

    }
}