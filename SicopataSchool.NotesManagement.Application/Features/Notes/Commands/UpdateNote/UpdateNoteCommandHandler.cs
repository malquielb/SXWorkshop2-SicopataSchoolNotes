using AutoMapper;
using MediatR;
using SicopataSchool.NotesManagement.Application.Contracts.Persistence;
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
        private readonly IAsyncRepository<Note> _asyncRepository;
        private readonly IMapper _mapper;

        public UpdateNoteCommandHandler(IAsyncRepository<Note> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var noteToUpdate = await _asyncRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, noteToUpdate, typeof(UpdateNoteCommand), typeof(Note));
            return Unit.Value;
        }
    }
}
