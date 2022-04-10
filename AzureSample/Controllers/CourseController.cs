using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureSample.Models;
using AzureSample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AzureSample.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _course_service;
        private readonly IConfiguration _configuration;

        public CourseController(ICourseService _svc,IConfiguration configuration)
        {
            _course_service = _svc;
            _configuration = configuration;
        }

        // The Index method is used to get a list of courses and return it to the view
        public IActionResult Index()
        {
            IEnumerable<Course> _course_list = _course_service.GetCourses(_configuration.GetConnectionString("SQLConnection"));
            return View(_course_list);
        }
    }
}
