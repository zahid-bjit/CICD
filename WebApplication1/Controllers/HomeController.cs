using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientService _TransientService1;
        private readonly ITransientService _TransientService2;

        private readonly IScopedService _ScopedService1;
        private readonly IScopedService _ScopedService2;

        private readonly ISingletonService _SingletonService1;
        private readonly ISingletonService _SingletonService2;


        //private readonly ITransientService _ts;


        public HomeController(ILogger<HomeController> logger,
            ITransientService TransientService1,
            ITransientService TransientService2,
            IScopedService ScopedService1,
            IScopedService ScopedService2,
            ISingletonService SingletonService1,
            ISingletonService SingletonService2
            )
        {
            _logger = logger;

            _TransientService1 = TransientService1;
            _TransientService2 = TransientService2;

            _ScopedService1 = ScopedService1;
            _ScopedService2 = ScopedService2;

            _SingletonService1 = SingletonService1;
            _SingletonService2 = SingletonService2;

            //_ts = new TransientService();
            //_ts.GetGuid();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DI()
        {
            var TransientServiceGuid1 = _TransientService1.GetGuid();
            var TransientServiceGuid2 = _TransientService2.GetGuid();

            var ScopedServiceGuid1 = _ScopedService1.GetGuid();
            var ScopedServiceGuid2 = _ScopedService2.GetGuid();

            var SingletonServiceGuid1 = _SingletonService1.GetGuid();
            var SingletonServiceGuid2 = _SingletonService2.GetGuid();

            StringBuilder messages = new StringBuilder();
            messages.Append($"Transient 1: {TransientServiceGuid1}\n");
            messages.Append($"Transient 2: {TransientServiceGuid2}\n\n");

            messages.Append($"Scoped 1: {ScopedServiceGuid1}\n");
            messages.Append($"Scoped 2: {ScopedServiceGuid2}\n\n");

            messages.Append($"Singleton 1: {SingletonServiceGuid1}\n");
            messages.Append($"Singleton 2: {SingletonServiceGuid2}");

            return Ok(messages.ToString());
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
