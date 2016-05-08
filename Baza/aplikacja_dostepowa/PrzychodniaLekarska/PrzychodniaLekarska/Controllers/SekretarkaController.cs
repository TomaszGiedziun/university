using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrzychodniaLekarska.Models;

namespace PrzychodniaLekarska.Controllers
{
    public class SekretarkaController : Controller
    {
        // GET: Sekretarka
        public ActionResult Index()
        {
            List<SekretarkaModel> sekretarkaList = new List<SekretarkaModel>();
            ISekretarkaService service = new SekretarkaService();

            sekretarkaList = service.GetAllSekretarka();

            return View(sekretarkaList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SekretarkaModel sekretarka)
        {
            if (ModelState.IsValid)
            {
                ISekretarkaService service = new SekretarkaService();
                service.AddSekretarka(sekretarka);

                return RedirectToAction("Index");
            }

            return View(sekretarka);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISekretarkaService service = new SekretarkaService();
            service.DeleteSekretarkaById(id.Value);

            return RedirectToAction("Index");
        }

        // Called from Index (only id) or Edit (id and delete) view
        public ActionResult Edit(int? id, bool? delete)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ISekretarkaService service = new SekretarkaService();
            SekretarkaModel sekretarka = new SekretarkaModel();
            sekretarka = service.GetSekretarkaById(id.Value);

            if (sekretarka == null)
            {
                return HttpNotFound();
            }

            if (delete.HasValue)
            {
                service.DeleteSekretarka(sekretarka);
                return RedirectToAction("Index");
            }

            return View(sekretarka);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SekretarkaModel sekretarka)
        {
            if (ModelState.IsValid)
            {
                ISekretarkaService service = new SekretarkaService();
                service.EditSekretarka(sekretarka);

                return RedirectToAction("Index");
            }

            return View(sekretarka);
        }
    }
}