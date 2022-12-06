using emonboardingAppApi.model.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeonboarding.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]

    public class EmployeeOnboardingController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeOnboardingController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
    }
}
