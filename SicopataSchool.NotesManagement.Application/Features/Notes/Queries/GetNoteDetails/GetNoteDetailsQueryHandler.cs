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
        private readonly IBaseRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(IBaseRepository<Note> baseRepository, IBaseRepository<Student> studentRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var note = await _baseRepository.GetByIdAsync(request.Id);
            var student = await _studentRepository.GetByIdAsync(note.StudentId);
            
            var response = _mapper.Map<NoteDetailsVm>(note);
            response.Student = _mapper.Map<NoteDetailsStudentDto>(student);

            return response;
        }
    }
}
