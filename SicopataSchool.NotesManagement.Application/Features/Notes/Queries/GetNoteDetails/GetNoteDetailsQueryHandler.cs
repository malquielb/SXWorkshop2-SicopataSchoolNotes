using AutoMapper;
using MediatR;
using SicopataSchool.NotesManagement.Application.Contracts.Persistence;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly IBaseRepository<Note> _baseRepository;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(IBaseRepository<Note> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var note = await _baseRepository.GetByIdAsync(request.Id);
            return _mapper.Map<NoteDetailsVm>(note);
        }
    }
}
