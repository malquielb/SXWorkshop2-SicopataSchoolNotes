using AutoMapper;
using MediatR;
using SicopataSchool.NotesManagement.Application.Contracts.Persistence;
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
        private readonly IAsyncRepository<Note> _asyncRepository;
        private readonly IMapper _mapper;

        public CreateNoteCommandHandler(IAsyncRepository<Note> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<CreateNoteResponseVm> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = _mapper.Map<Note>(request);

            // TODO: assign student id
            // TODO: manage note shared
            note.Created = DateTime.Now;

            var response = await _asyncRepository.AddAsync(note);

            return _mapper.Map<CreateNoteResponseVm>(response);
        }
    }
}
