using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Contracts.Persistence
{
    public interface INoteRepository : IBaseRepository<Note>
    {
        Task<List<Note>> GetPublicNotes();
    }
}
