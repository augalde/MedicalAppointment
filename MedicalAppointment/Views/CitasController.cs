using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicalAppointment.Models;

namespace MedicalAppointment.Views
{
    public class CitasController : Controller
    {
        private MedicalAppointmentContext db = new MedicalAppointmentContext();

        // GET: Citas
        public async Task<ActionResult> Index()
        {
            var citas = db.Citas.Include(c => c.PacienteId).Include(c => c.TipoCitaId);
            return View(await citas.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = await db.Citas.FindAsync(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Pacientes, "PacienteId", "Nombre");
            ViewBag.Id = new SelectList(db.TipoCitas, "TipoCitaId", "Descripcion");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Fecha")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(cita);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Pacientes, "PacienteId", "Nombre", cita.Id);
            ViewBag.Id = new SelectList(db.TipoCitas, "TipoCitaId", "Descripcion", cita.Id);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = await db.Citas.FindAsync(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Pacientes, "PacienteId", "Nombre", cita.Id);
            ViewBag.Id = new SelectList(db.TipoCitas, "TipoCitaId", "Descripcion", cita.Id);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Fecha")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Pacientes, "PacienteId", "Nombre", cita.Id);
            ViewBag.Id = new SelectList(db.TipoCitas, "TipoCitaId", "Descripcion", cita.Id);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = await db.Citas.FindAsync(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cita cita = await db.Citas.FindAsync(id);
            db.Citas.Remove(cita);
            await db.SaveChangesAsync();
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
