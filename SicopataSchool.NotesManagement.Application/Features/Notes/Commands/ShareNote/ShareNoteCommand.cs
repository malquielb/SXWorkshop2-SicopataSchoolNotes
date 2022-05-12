using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Commands.ShareNote
{
    public class ShareNoteCommand : IRequest
    {
        public int NoteId { get; set; }
        public int StudentId { get; set; }
    }
}
