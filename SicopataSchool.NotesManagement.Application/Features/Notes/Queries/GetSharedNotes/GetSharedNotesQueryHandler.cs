using AutoMapper;
using MediatR;
using SicopataSchool.NotesManagement.Application.Contracts.Persistence;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetSharedNotes
{
    public class GetSharedNotesQueryHandler : IRequestHandler<GetSharedNotesQuery, List<SharedNoteVm>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public GetSharedNotesQueryHandler(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task<List<SharedNoteVm>> Handle(GetSharedNotesQuery request, CancellationToken cancellationToken)
        {
            var notesList = await _noteRepository.GetSharedNotes();
            return _mapper.Map<List<SharedNoteVm>>(notesList);
        }
    }
}
