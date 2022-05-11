using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .MaximumLength(125);

            RuleFor(p => p.LastName)
                .NotEmpty()
                .MaximumLength(125);
        }
    }
}
