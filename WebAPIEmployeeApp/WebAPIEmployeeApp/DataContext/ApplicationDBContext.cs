using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPIEmployeeApp.Models;

namespace WebAPIEmployeeApp.DataContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
