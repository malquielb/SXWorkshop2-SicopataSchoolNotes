using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SicopataSchool.NotesManagement.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Identity
{
    public class SicopataSchoolIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SicopataSchoolIdentityDbContext(DbContextOptions<SicopataSchoolIdentityDbContext> options) 
            : base(options)
        {
        }
    }
}
