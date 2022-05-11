using AutoMapper;
using MediatR;
using SicopataSchool.NotesManagement.Application.Contracts.Persistence;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentResponseVm>
    {
        private readonly IAsyncRepository<Student> _asyncRepository;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IAsyncRepository<Student> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<CreateStudentResponseVm> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var response = await _asyncRepository.AddAsync(student);

            return _mapper.Map<CreateStudentResponseVm>(response);
        }
    }
}
