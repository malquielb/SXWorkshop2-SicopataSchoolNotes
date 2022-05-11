using Microsoft.EntityFrameworkCore;
using SicopataSchool.NotesManagement.Application.Contracts.Persistence;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Persistence.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(SicopataSchoolDbContext context) : base(context)
        {
        }

        public async Task<List<Note>> GetPublicNotes()
        {
            return await _context.Notes.Where(note => note.IsPublic)
                                            .ToListAsync();
        }
    }
}
