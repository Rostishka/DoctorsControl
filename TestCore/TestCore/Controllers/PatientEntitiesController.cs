using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entity;

namespace TestCore.Controllers
{
    public class PatientEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientEntities
        public async Task<IActionResult> Index()
        {

            ViewBag.list = await _context.Reviews.ToListAsync();
            return View(await _context.Patients.ToListAsync());
        }

        // GET: PatientEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientEntity = await _context.Patients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (patientEntity == null)
            {
                return NotFound();
            }

            return View(patientEntity);
        }

        // GET: PatientEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,Email,Password")] PatientEntity patientEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientEntity);
        }

        // GET: PatientEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientEntity = await _context.Patients.SingleOrDefaultAsync(m => m.Id == id);
            if (patientEntity == null)
            {
                return NotFound();
            }
            return View(patientEntity);
        }

        // POST: PatientEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,Email,Password")] PatientEntity patientEntity)
        {
            if (id != patientEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientEntityExists(patientEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patientEntity);
        }

        // GET: PatientEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientEntity = await _context.Patients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (patientEntity == null)
            {
                return NotFound();
            }

            return View(patientEntity);
        }

        // POST: PatientEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientEntity = await _context.Patients.SingleOrDefaultAsync(m => m.Id == id);
            _context.Patients.Remove(patientEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientEntityExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
