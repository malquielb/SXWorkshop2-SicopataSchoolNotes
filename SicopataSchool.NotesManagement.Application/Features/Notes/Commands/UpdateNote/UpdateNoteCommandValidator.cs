using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty();

            RuleFor(p => p.Title)
                .MaximumLength(50);

            RuleFor(p => p.Body)
                .MaximumLength(250);

            RuleFor(p => p.IsPublic)
                .NotEmpty();
        }
    }
}
