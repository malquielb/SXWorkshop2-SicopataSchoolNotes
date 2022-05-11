using AutoMapper;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetPublicNotes
{
    public class PublicNoteMappingProfile : Profile
    {
        public PublicNoteMappingProfile()
        {
            CreateMap<Note, PublicNoteVm>();
        }
    }
}
