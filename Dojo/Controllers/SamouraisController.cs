using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using Dojo.Data;
using Dojo.Models;

namespace Dojo.Controllers
{
    public class SamouraisController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SamouraisVM vm = new SamouraisVM();

            vm.Samourai = db.Samourais.FirstOrDefault(x => x.Id == id);
            

            if (vm.Samourai == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraisVM vm = new SamouraisVM();

            vm.Armes = db.Armes.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Arts = db.ArtMartials.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            return View(vm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraisVM vm)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = vm.Samourai;

               
                
                samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.IdArme);


                if (samourai.Arts != null)
                {
                    samourai.Arts = db.ArtMartials.Where(x => vm.IdsArts.Contains(x.Id)).ToList();
                }
                
                db.Samourais.Add(samourai);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.Armes = db.Armes.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Arts = db.ArtMartials.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            
            SamouraisVM vm = new SamouraisVM();
                        
            vm.Armes = db.Armes.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            vm.Arts = db.ArtMartials.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            vm.Samourai = db.Samourais.FirstOrDefault(x => x.Id == id);

            if (vm.Samourai.Arme != null)
            {
                vm.IdArme = vm.Samourai.Arme.Id;
            }

            if (vm.Samourai.Arts.Any())
            {
                
                vm.IdsArts = vm.Samourai.Arts.Select(x => x.Id).ToList();
            }

            
            
            return View(vm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraisVM vm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vm.Samourai).State = EntityState.Modified;




                Samourai samourai = db.Samourais.Include(x => x.Arme).Include(z => z.Arts).FirstOrDefault(x => x.Id == vm.Samourai.Id);

                samourai.Nom = vm.Samourai.Nom;
                samourai.Force = vm.Samourai.Force;


                samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.IdArme);

                if (samourai.Arts != null)
                {
                    samourai.Arts = db.ArtMartials.Where(x => vm.IdsArts.Contains(x.Id)).ToList();
                }
                
                

               
                db.SaveChanges();
                return RedirectToAction("Index");

               
            }
            vm.Armes = db.Armes.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            vm.Arts = db.ArtMartials.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            return View(vm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SamouraisVM vm = new SamouraisVM();

            vm.Samourai = db.Samourais.FirstOrDefault(x => x.Id == id);


            


            if (vm.Samourai == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
