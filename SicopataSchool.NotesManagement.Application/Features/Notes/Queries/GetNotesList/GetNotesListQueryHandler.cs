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
        private readonly IBaseRepository<Note> _baseRepository;
        private readonly IMapper _mapper;

        public GetNotesListQueryHandler(IBaseRepository<Note> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public Task<IQueryable<ListNoteVm>> Handle(GetNotesListQuery request, CancellationToken cancellationToken)
        {
            var notesList = _baseRepository.ListAll();
            return Task.FromResult(_mapper.Map<IQueryable<ListNoteVm>>(notesList));
        }
    }
}
