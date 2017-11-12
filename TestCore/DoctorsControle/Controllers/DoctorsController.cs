using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;
using DAL.Interfaces;
using DAL.Models;
using DoctorsControle.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DoctorsControle.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorsController(
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
        }

        // GET: AllDoctors
        [HttpGet]
        public async Task<IActionResult> AllDoctors()
        {
            var doctors = _userManager.Users.Where(u => u.Role == UserRole.Doctor).ToList();//_unitOfWork.UserRepository.GetManyAsync(u => u.Role == UserRole.Doctor, null);
            return View(doctors);
        }
    }
}
