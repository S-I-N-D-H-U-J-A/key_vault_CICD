using DBFirstapp.data;
using DBFirstapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DBFirstapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
                
            List<ViewModel> vm = PopulateViewModel();
                      
            return View(vm);
        }

        public List<ViewModel> PopulateViewModel()
        {
            
            EmployeeContext employeeContext = new EmployeeContext(_configuration);
            var data = employeeContext.EmployeeLogins.ToList();
            List<ViewModel> items = new List<ViewModel>();

            for (int i = 0; i < data.Count; i++)
            {
                items.Add(new ViewModel()
                {
                    Id = data[i].Id,
                    LoginId = data[i].LoginId,
                    Password = data[i].Password,
                    EmpoyeeName = data[i].EmpoyeeName,
                    DepartmentId = data[i].DepartmentId
                });
            }

            return items;
        }
        public class ViewModel
        {
            public int Id { get; set; }
            public string? LoginId { get; set; }
            public string? Password { get; set; }
            public string? EmpoyeeName { get; set; } = null;
            public int? DepartmentId { get; set; }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}