using AutoMapper;
using MediatR;
using SicopataSchool.NotesManagement.Application.Contracts.Persistence;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Students.Queries.GetStudentDetails
{
    public class GetStudentDetailsQueryHandler : IRequestHandler<GetStudentDetailsQuery, StudentDetailsVm>
    {
        private readonly IBaseRepository<Student> _baseRepository;
        private readonly IMapper _mapper;

        public GetStudentDetailsQueryHandler(IBaseRepository<Student> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<StudentDetailsVm> Handle(GetStudentDetailsQuery request, CancellationToken cancellationToken)
        {
            var student = await _baseRepository.GetByIdAsync(request.Id);
            return _mapper.Map<StudentDetailsVm>(student);
        }
    }
}
