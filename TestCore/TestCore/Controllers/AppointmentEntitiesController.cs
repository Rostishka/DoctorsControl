using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entity;
using DAL.ViewModels;

namespace TestCore.Controllers
{
    public class AppointmentEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppointmentEntities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointments.Include(a => a.Doctor).Include(a => a.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AppointmentEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentEntity = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (appointmentEntity == null)
            {
                return NotFound();
            }

            return View(appointmentEntity);
        }

        // GET: AppointmentEntities/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id");
            return View();
        }

        // POST: AppointmentEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time,DoctorId,PatientId,Comment")] AppointmentViewModel appointmentViewModel)
        {
            var appointmentEntity = new AppointmentEntity()
            {
                DoctorId = appointmentViewModel.DoctorId,
        //        Doctor = new DoctorEntity(),
                PatientId = appointmentViewModel.PatientId,
                Time = appointmentViewModel.Time,
                Comment = appointmentViewModel.Comment,
        //        Patient = new PatientEntity(),
                ReviewStatuse = AppointmentStatuse.Waiting
            };
            if (ModelState.IsValid)
            {
                _context.Add(appointmentEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", appointmentEntity.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", appointmentEntity.PatientId);
            return View(appointmentEntity);
        }

        // GET: AppointmentEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentEntity = await _context.Appointments.SingleOrDefaultAsync(m => m.Id == id);
            if (appointmentEntity == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", appointmentEntity.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", appointmentEntity.PatientId);
            return View(appointmentEntity);
        }

        // POST: AppointmentEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,DoctorId,PatientId,Comment,ReviewStatuse")] AppointmentEntity appointmentEntity)
        {
            if (id != appointmentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentEntityExists(appointmentEntity.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", appointmentEntity.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", appointmentEntity.PatientId);
            return View(appointmentEntity);
        }

        // GET: AppointmentEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentEntity = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (appointmentEntity == null)
            {
                return NotFound();
            }

            return View(appointmentEntity);
        }

        // POST: AppointmentEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentEntity = await _context.Appointments.SingleOrDefaultAsync(m => m.Id == id);
            _context.Appointments.Remove(appointmentEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentEntityExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
