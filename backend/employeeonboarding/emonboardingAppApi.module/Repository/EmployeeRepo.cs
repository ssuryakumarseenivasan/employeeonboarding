using emonboardingAppApi.model.Abstract;
using EmplyeeData.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace emonboardingAppApi.model.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeDbContext _empdbcontext;

        public EmployeeRepo(EmployeeDbContext empdb)
        {
            _empdbcontext = empdb;
        }
    }
}
