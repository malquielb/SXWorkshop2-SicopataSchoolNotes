using AutoMapper;
using MediatR;
using SicopataSchool.NotesManagement.Application.Contracts.Persistence;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetPublicNotes
{
    public class GetPublicNotesQueryHandler : IRequestHandler<GetPublicNotesQuery, List<PublicNoteVm>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public GetPublicNotesQueryHandler(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task<List<PublicNoteVm>> Handle(GetPublicNotesQuery request, CancellationToken cancellationToken)
        {
            var notesList = await _noteRepository.GetPublicNotes();
            return _mapper.Map<List<PublicNoteVm>>(notesList);
        }
    }
}
