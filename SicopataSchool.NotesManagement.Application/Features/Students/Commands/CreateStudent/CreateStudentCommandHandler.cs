using AutoMapper;
using MediatR;
using SicopataSchool.NotesManagement.Application.Contracts.Persistence;
using SicopataSchool.NotesManagement.Application.Exceptions;
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
        private readonly IBaseRepository<Student> _baseRepository;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IBaseRepository<Student> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<CreateStudentResponseVm> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateStudentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var student = _mapper.Map<Student>(request);
            var response = await _baseRepository.AddAsync(student);

            return _mapper.Map<CreateStudentResponseVm>(response);
        }
    }
}
