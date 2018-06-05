using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.Models;

namespace Garage2.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private Garage2Context db = new Garage2Context();

        // GET: ParkedVehicles
        public ActionResult ParkedVehicles(string sortOrder)
        {
            Debug.WriteLine("sortOrder: " + sortOrder);
            ViewBag.RegNoSortParam = String.IsNullOrEmpty(sortOrder) ? "regno_desc" : "";
            ViewBag.BrandSortParam = sortOrder == "brand" ? "brand_desc" : "brand";
            var parkedVehicles = from s in db.ParkedVehicles
                                 select s;
            switch (sortOrder)
            {
                case "regno_desc":
                    parkedVehicles = parkedVehicles.OrderByDescending(pv => pv.RegNo);
                    break;
                case "brand":
                    parkedVehicles = parkedVehicles.OrderBy(pv => pv.Brand);
                    break;
                case "brand_desc":
                    parkedVehicles = parkedVehicles.OrderByDescending(pv => pv.Brand);
                    break;
                default:
                    parkedVehicles = parkedVehicles.OrderBy(pv => pv.RegNo);
                    break;
            }

            return View(parkedVehicles.ToList());
        }

        // GET: ParkedVehicles/Receipt/1
        public ActionResult Receipt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }

            Receipt receipt = new Receipt
            {
                RegNo = parkedVehicle.RegNo,
                CheckInTime = parkedVehicle.CheckInTime
            };

            return View(receipt);
        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/CheckIn
        public ActionResult CheckIn()
        {
            return View();
        }

        // POST: ParkedVehicles/CheckIn
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckIn([Bind(Include = "Id,VehicleType,Brand,Color,RegNo,Model,NoWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                parkedVehicle.CheckInTime = DateTime.Now;
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("ParkedVehicles");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleType,Brand,Color,RegNo,Model,NoWheels")] ParkedVehicle parkedVehicle)
        {
            if (!ModelState.IsValid) return View(parkedVehicle);

            ParkedVehicle parked = db.ParkedVehicles.Find(parkedVehicle.Id);
            parked.Id = parkedVehicle.Id;
            parked.VehicleType = parkedVehicle.VehicleType;
            parked.Brand = parkedVehicle.Brand;
            parked.Color = parkedVehicle.Color;
            parked.RegNo = parkedVehicle.RegNo;
            parked.Model = parkedVehicle.Model;
            parked.NoWheels = parkedVehicle.NoWheels;

            db.Entry(parked).State = EntityState.Modified;
            db.Entry(parked).Property(p => p.CheckInTime).IsModified = false;
            db.SaveChanges();

            return RedirectToAction("ParkedVehicles");
        }

        // GET: ParkedVehicles/CheckOut/5
        public ActionResult CheckOut(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }

            //parkedVehicle.CheckOutTime = DateTime.Now;
            //Receipt receipt = new Receipt
            //{
            //    CheckInTime = receipt.CheckInTime,
            //    CheckOutTime = receipt.CheckOutTime,
            //    RegNo = receipt.RegNo
            //};

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/CheckOut/5
        [HttpPost, ActionName("CheckOut")]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOutConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("ParkedVehicles");
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
