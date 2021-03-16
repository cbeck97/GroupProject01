using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class SignUpContext : DbContext
    {
        public SignUpContext (DbContextOptions<SignUpContext> options):base(options)
        {
            //this is aa test
        }
        public DbSet<SignUp> SignUp { get; set; }
        public DbSet<Appointments> Appointments {get; set;}
    }
}
