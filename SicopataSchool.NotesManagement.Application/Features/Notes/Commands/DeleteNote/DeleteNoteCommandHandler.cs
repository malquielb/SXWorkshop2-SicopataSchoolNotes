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

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly IBaseRepository<Note> _baseRepository;
        private readonly IMapper _mapper;

        public DeleteNoteCommandHandler(IBaseRepository<Note> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteNoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var note = await _baseRepository.GetByIdAsync(request.Id);
            await _baseRepository.DeleteAsync(note);
            return Unit.Value;
        }
    }
}
