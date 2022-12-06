using EmplyeeData.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmplyeeData.Database
{
    public class EmployeeDbContext : DbContext
    {

        public EmployeeDbContext()
    {

    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {

    }
        public virtual DbSet<designation> Designations { get; set; }
    }
}
