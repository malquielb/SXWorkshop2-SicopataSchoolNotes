using AutoMapper;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteMappingProfile : Profile
    {
        public CreateNoteMappingProfile()
        {
            CreateMap<CreateNoteCommand, Note>();
            CreateMap<Note, CreateNoteResponseVm>();
        }
    }
}
