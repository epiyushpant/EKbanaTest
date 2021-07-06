using EKbanaTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions context) : base(context)
        {

        }

        public DbSet<Employee> Employees { get; set; }     
        public DbSet<Role> Roles { get; set; }
    }
}
