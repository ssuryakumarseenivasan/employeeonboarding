using emonboardingAppApi.model.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace emonboardingAppApi.model.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeerepo;

        public EmployeeService(IEmployeeRepo employeerepo)
        {
            _employeerepo = employeerepo;
        }
    }
}
