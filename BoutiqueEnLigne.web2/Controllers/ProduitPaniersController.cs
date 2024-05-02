using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoutiqueEnLigne.web2;
using BoutiqueEnLigne2.web.Models;

namespace BoutiqueEnLigne.web2.Controllers
{
    public class ProduitPaniersController : Controller
    {
        private BoutiqueEnLigne2DbContext db = new BoutiqueEnLigne2DbContext();

        // GET: ProduitPaniers
        public ActionResult Index()
        {
            var produitPaniers = db.produitPaniers.Include(p => p.Commande).Include(p => p.Panier);
            return View(produitPaniers.ToList());
        }

        // GET: ProduitPaniers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduitPanier produitPanier = db.produitPaniers.Find(id);
            if (produitPanier == null)
            {
                return HttpNotFound();
            }
            return View(produitPanier);
        }

        // GET: ProduitPaniers/Create
        public ActionResult Create()
        {
            ViewBag.CommandeId = new SelectList(db.Commandes, "Id", "Id");
            ViewBag.PanierId = new SelectList(db.Panier, "IdPanier", "IdPanier");
            return View();
        }

        // POST: ProduitPaniers/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProduitId,PanierId,Quantite,CommandeId")] ProduitPanier produitPanier)
        {
            if (ModelState.IsValid)
            {
                db.produitPaniers.Add(produitPanier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommandeId = new SelectList(db.Commandes, "Id", "Id", produitPanier.CommandeId);
            ViewBag.PanierId = new SelectList(db.Panier, "IdPanier", "IdPanier", produitPanier.PanierId);
            return View(produitPanier);
        }

        // GET: ProduitPaniers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduitPanier produitPanier = db.produitPaniers.Find(id);
            if (produitPanier == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommandeId = new SelectList(db.Commandes, "Id", "Id", produitPanier.CommandeId);
            ViewBag.PanierId = new SelectList(db.Panier, "IdPanier", "IdPanier", produitPanier.PanierId);
            return View(produitPanier);
        }

        // POST: ProduitPaniers/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProduitId,PanierId,Quantite,CommandeId")] ProduitPanier produitPanier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produitPanier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommandeId = new SelectList(db.Commandes, "Id", "Id", produitPanier.CommandeId);
            ViewBag.PanierId = new SelectList(db.Panier, "IdPanier", "IdPanier", produitPanier.PanierId);
            return View(produitPanier);
        }

        // GET: ProduitPaniers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProduitPanier produitPanier = db.produitPaniers.Find(id);
            if (produitPanier == null)
            {
                return HttpNotFound();
            }
            return View(produitPanier);
        }

        // POST: ProduitPaniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProduitPanier produitPanier = db.produitPaniers.Find(id);
            db.produitPaniers.Remove(produitPanier);
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
