using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.ReviewViewModels;
using DoctorsControle.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAL.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DoctorsControle.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ReviewsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private static string _doctorId;

        public ReviewsController(
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
        public async Task<IActionResult> GetAllReviewsForCurrentUser()
        {
            var currentUser = await _userManager.FindByEmailAsync(User.Identity.Name);
            //var user = await _context.Users.FindAsync(user.Id);
            var result = _unitOfWork.ReviewsRepository.GetManyAsync(r => r.PatientId.Equals(currentUser.Id), null, nameof(ReviewEntity.ApplicationUser));
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateReview(string Id)
        {
            var a = await _context.ApplicationUsers.Where(u => u.Role == UserRole.Doctor).FirstOrDefaultAsync();
            _doctorId = a.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewViewModel reviewViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                var reviewEntity = new ReviewEntity()
                {
                    ApplicationUserId = _doctorId,
                    Advantage = reviewViewModel.Advantage,
                    Comment = reviewViewModel.Comment,
                    Disadvantage = reviewViewModel.Disadvantage,
                    Mark = reviewViewModel.Mark,
                    PatientId = user.Id,
                    PatientEmail = reviewViewModel.PatientEmail
                };

                //_context.ApplicationUsers.

                //var a = await _context.ApplicationUsers.LastOrDefaultAsync();
                //_doctorId = a.Id;

                //reviewEntity.ApplicationUserId = a.Id;

                await _unitOfWork.ReviewsRepository.CreateAsync(reviewEntity);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(GetAllReviewsForCurrentUser));
            }
            return View(reviewViewModel);
        }
    }
}
