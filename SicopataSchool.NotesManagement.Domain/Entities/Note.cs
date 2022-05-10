using SicopataSchool.NotesManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublic { get; set; }
        public bool Shared { get; set; }
        public DateTimeOffset Created { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
