using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetSharedNotes
{
    public class GetSharedNotesQuery : IRequest<List<SharedNoteVm>>
    {
    }
}
