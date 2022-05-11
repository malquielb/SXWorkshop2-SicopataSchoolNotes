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

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, CreateNoteResponseVm>
    {
        private readonly IBaseRepository<Note> _baseRepository;
        private readonly IMapper _mapper;

        public CreateNoteCommandHandler(IBaseRepository<Note> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<CreateNoteResponseVm> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateNoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var note = _mapper.Map<Note>(request);

            // TODO: assign student id
            note.StudentId = 1;
            // TODO: manage note shared
            note.Created = DateTime.Now;

            var response = await _baseRepository.AddAsync(note);

            return _mapper.Map<CreateNoteResponseVm>(response);
        }
    }
}
