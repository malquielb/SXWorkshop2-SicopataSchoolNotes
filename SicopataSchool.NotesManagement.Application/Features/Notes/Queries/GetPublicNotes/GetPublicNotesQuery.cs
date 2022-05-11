using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetPublicNotes
{
    public class GetPublicNotesQuery : IRequest<List<PublicNoteVm>>
    {
    }
}
