using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;
using DAL.Interfaces;
using DAL.Models;
using DAL.ViewModels;
using DoctorsControle.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DoctorsControle.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AppointmentsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private static string _doctorId;

        public AppointmentsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            ApplicationDbContext context,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointmentsForCurrentUser()
        {
            ResponseModel<IEnumerable<AppointmentEntity>> results= new ResponseModel<IEnumerable<AppointmentEntity>>();

            var currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (currentUser.Role == UserRole.Patient)
            {
                results.Data = _unitOfWork.AppointmentRepository.GetManyAsync(a => a.PatientId.Equals(currentUser.Id), null, nameof(AppointmentEntity.Doctor));
                //foreach (var app in _unitOfWork.AppointmentRepository.GetManyAsync(a => a.PatientId.Equals(currentUser.Id), null, nameof(AppointmentEntity.Doctor)))
                //{
                //    results 
                //}
                //results = new  AppointmentViewModel();
                results.IsDoctor = false;
            }
            else if(currentUser.Role == UserRole.Doctor)
            {
                results.Data = _unitOfWork.AppointmentRepository.GetManyAsync(a => a.DoctorId.Equals(currentUser.Id), null, nameof(AppointmentEntity.Patient));
                results.IsDoctor = true;
            }
            //var user = await _context.Users.FindAsync(user.Id);
            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAppointment()
        {
            var a = await _context.ApplicationUsers.Where(u => u.Role == UserRole.Doctor).FirstOrDefaultAsync();
            _doctorId = a.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentViewModel appointmentViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                var appointmentEntity = new AppointmentEntity()
                {
                    DoctorId = _doctorId,
                    ReviewStatuse = AppointmentStatuse.Waiting,
                    Comment = appointmentViewModel.Comment,
                    PatientId = user.Id,
                    Time = appointmentViewModel.Time
                };

                //_context.ApplicationUsers.

                //var a = await _context.ApplicationUsers.LastOrDefaultAsync();
                //_doctorId = a.Id;

                //reviewEntity.ApplicationUserId = a.Id;

                await _unitOfWork.AppointmentRepository.CreateAsync(appointmentEntity);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(GetAllAppointmentsForCurrentUser));
            }
            return View(appointmentViewModel);
        }
    }
}
