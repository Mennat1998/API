using Day2.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.DAL.Data.Context
{
    public class SystemContext :DbContext
    {

        public DbSet<Ticket> Ticket => Set<Ticket>();
        public DbSet<Developer> Developer => Set<Developer>();

        public DbSet<Departments> Department => Set<Departments>();

        public SystemContext (DbContextOptions<SystemContext> options) : base (options)
        {

        }
    }
}
