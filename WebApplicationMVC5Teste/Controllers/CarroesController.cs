using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVC5Teste.Models;

namespace WebApplicationMVC5Teste.Controllers
{
    public class CarroesController : Controller
    {
        private connectioEntities db = new connectioEntities();

        // GET: Carroes
        public ActionResult Index()
        {
            var carro = db.Carro.Include(c => c.Modelo);            
            return View(carro.ToList());
        }

        // GET: Carroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carroes/Create
        public ActionResult Create()
        {
            ViewBag.IDmodelo = new SelectList(db.Modelo, "IDmodelo", "NomeModelo");
            return View();
        }

        // POST: Carroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDcarro,Nome,Ano,IDmodelo")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Carro.Add(carro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDmodelo = new SelectList(db.Modelo, "IDmodelo", "NomeModelo", carro.IDmodelo);
            return View(carro);
        }

        // GET: Carroes/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.isEditaCarro = false;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDmodelo = new SelectList(db.Modelo, "IDmodelo", "NomeModelo", carro.IDmodelo);

            //var script = "$(\"#myModal\").modal({ show: true })";

            //ViewBag.scriptModal = script;


            return View(carro);
        }

        // POST: Carroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDcarro,Nome,Ano,IDmodelo")] Carro carro)
        {
            if(carro.IDcarro == 1)
            if (ModelState.IsValid)
            {               
                    db.Entry(carro).State = EntityState.Modified;
                    db.SaveChanges();
                    
                    return RedirectToAction("Index");                        
            }
            ViewBag.IDmodelo = new SelectList(db.Modelo, "IDmodelo", "NomeModelo", carro.IDmodelo);
            ViewBag.isEditaCarro = true;

            ViewBag.javascript = "../../Scripts/Modais/ModalAlert.js";
           
            return View(carro);
        }

        public PartialViewResult PartialScriptModal()
        {
            
            return PartialView();
        }

        public PartialViewResult ModalAlerta()
        {

            return PartialView();
        }

        // GET: Carroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = db.Carro.Find(id);
            db.Carro.Remove(carro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
