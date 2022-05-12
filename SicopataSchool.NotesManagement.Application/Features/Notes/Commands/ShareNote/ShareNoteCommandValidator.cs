using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Commands.ShareNote
{
    public class ShareNoteCommandValidator : AbstractValidator<ShareNoteCommand>
    {
        public ShareNoteCommandValidator()
        {
            RuleFor(p => p.StudentId)
                .NotEmpty();

            RuleFor(p => p.NoteId)
                .NotEmpty();
        }
    }
}
