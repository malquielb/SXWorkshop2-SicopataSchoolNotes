using Microsoft.AspNetCore.Identity;
using SicopataSchool.NotesManagement.Application.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Identity.Models
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public int StudentId { get; set; }
    }
}
