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

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly IBaseRepository<Note> _baseRepository;
        private readonly IMapper _mapper;

        public UpdateNoteCommandHandler(IBaseRepository<Note> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var noteToUpdate = await _baseRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, noteToUpdate, typeof(UpdateNoteCommand), typeof(Note));
            return Unit.Value;
        }
    }
}
