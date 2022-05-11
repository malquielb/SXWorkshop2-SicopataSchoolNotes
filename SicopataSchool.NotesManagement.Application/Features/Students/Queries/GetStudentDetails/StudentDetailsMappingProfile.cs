using AutoMapper;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Students.Queries.GetStudentDetails
{
    public class StudentDetailsMappingProfile : Profile
    {
        public StudentDetailsMappingProfile()
        {
            CreateMap<Student, StudentDetailsVm>();
        }
    }
}
