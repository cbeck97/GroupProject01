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
        public DbSet<SignUpContext> SignUp { get; set; }
        public DbSet<SignUpContext> Appointments {get; set;}
    }
}
