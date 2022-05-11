using AutoMapper;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsMappingProfile : Profile
    {
        public NoteDetailsMappingProfile()
        {
            CreateMap<Note, NoteDetailsVm>();
            CreateMap<Student, NoteDetailsStudentDto>();
        }
    }
}
