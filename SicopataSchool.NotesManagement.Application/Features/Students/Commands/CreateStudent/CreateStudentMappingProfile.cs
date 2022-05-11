using AutoMapper;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentMappingProfile : Profile
    {
        public CreateStudentMappingProfile()
        {
            CreateMap<CreateStudentCommand, Student>();
            CreateMap<Student, CreateStudentResponseVm>();
        }
    }
}
