using AutoMapper;
using MediatR;
using SicopataSchool.NotesManagement.Application.Contracts.Persistence;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetNotesList
{
    public class GetNotesListQueryHandler : IRequestHandler<GetNotesListQuery, IQueryable<ListNoteVm>>
    {
        private readonly IAsyncRepository<Note> _asyncRepository;
        private readonly IMapper _mapper;

        public GetNotesListQueryHandler(IAsyncRepository<Note> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<ListNoteVm>> Handle(GetNotesListQuery request, CancellationToken cancellationToken)
        {
            var notesList = await _asyncRepository.ListAllAsync();
            return _mapper.Map<IQueryable<ListNoteVm>>(notesList);
        }
    }
}
