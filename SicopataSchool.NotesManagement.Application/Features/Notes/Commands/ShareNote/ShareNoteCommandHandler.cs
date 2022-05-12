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

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Commands.ShareNote
{
    public class ShareNoteCommandHandler : IRequestHandler<ShareNoteCommand>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IBaseRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public ShareNoteCommandHandler(INoteRepository noteRepository, 
IBaseRepository<Student> studentRepository, IMapper mapper, IMediator mediator)
        {
            _noteRepository = noteRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ShareNoteCommand request, CancellationToken cancellationToken)
        {
            var validator = new ShareNoteCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var note = await _noteRepository.GetByIdAsync(request.NoteId);
            var student = await _studentRepository.GetByIdAsync(request.StudentId);

            if (note == null)
                throw new Exception($"Note with id = {request.NoteId} was not found.");

            if (student == null)
                throw new Exception($"Student with id = {request.StudentId} was not found.");

            note.StudentId = student.Id;
            note.Shared = true;
            await _noteRepository.AddAsync(note);

            return Unit.Value;
        }
    }
}
