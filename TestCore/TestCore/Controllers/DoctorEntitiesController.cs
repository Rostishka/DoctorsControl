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
    public class DoctorEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DoctorEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.ToListAsync());
        }

        // GET: DoctorEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorEntity = await _context.Doctors
                .SingleOrDefaultAsync(m => m.Id == id);
            if (doctorEntity == null)
            {
                return NotFound();
            }

            return View(doctorEntity);
        }

        // GET: DoctorEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,Email,Password,JobTitle,Information,Location,Procedures")] DoctorEntity doctorEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorEntity);
        }

        // GET: DoctorEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorEntity = await _context.Doctors.SingleOrDefaultAsync(m => m.Id == id);
            if (doctorEntity == null)
            {
                return NotFound();
            }
            return View(doctorEntity);
        }

        // POST: DoctorEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,Email,Password,JobTitle,Information,Location,Procedures")] DoctorEntity doctorEntity)
        {
            if (id != doctorEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorEntityExists(doctorEntity.Id))
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
            return View(doctorEntity);
        }

        // GET: DoctorEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorEntity = await _context.Doctors
                .SingleOrDefaultAsync(m => m.Id == id);
            if (doctorEntity == null)
            {
                return NotFound();
            }

            return View(doctorEntity);
        }

        // POST: DoctorEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorEntity = await _context.Doctors.SingleOrDefaultAsync(m => m.Id == id);
            _context.Doctors.Remove(doctorEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorEntityExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
