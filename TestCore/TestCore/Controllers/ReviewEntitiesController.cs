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
    public class ReviewEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReviewEntities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reviews.Include(r => r.Doctor).Include(r => r.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReviewEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewEntity = await _context.Reviews
                .Include(r => r.Doctor)
                .Include(r => r.Patient)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (reviewEntity == null)
            {
                return NotFound();
            }

            return View(reviewEntity);
        }

        // GET: ReviewEntities/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id");
            return View();
        }

        // POST: ReviewEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mark,Advantage,Disadvantage,Comment,PatientEmail,DoctorId,PatientId")] ReviewEntity reviewEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", reviewEntity.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", reviewEntity.PatientId);
            return View(reviewEntity);
        }

        // GET: ReviewEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewEntity = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (reviewEntity == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", reviewEntity.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", reviewEntity.PatientId);
            return View(reviewEntity);
        }

        // POST: ReviewEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mark,Advantage,Disadvantage,Comment,PatientEmail,DoctorId,PatientId")] ReviewEntity reviewEntity)
        {
            if (id != reviewEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewEntityExists(reviewEntity.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", reviewEntity.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", reviewEntity.PatientId);
            return View(reviewEntity);
        }

        // GET: ReviewEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewEntity = await _context.Reviews
                .Include(r => r.Doctor)
                .Include(r => r.Patient)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (reviewEntity == null)
            {
                return NotFound();
            }

            return View(reviewEntity);
        }

        // POST: ReviewEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewEntity = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            _context.Reviews.Remove(reviewEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewEntityExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
