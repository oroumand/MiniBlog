using FluentValidation;
using MiniBlog.Core.Contracts.Writers.Commands.CreateWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Utilities.Services.Localizations;

namespace MiniBlog.Core.ApplicationService.Writers.Commands.CreateWriter;
public class CreateWriterCommandValidator : AbstractValidator<CreateWriterCommand>
{
    public CreateWriterCommandValidator(ITranslator translator)
    {
        RuleFor(c => c.FirstName)
           .NotEmpty().WithMessage(translator["Required", "FirstName"]).WithErrorCode("Required")
           .NotNull().WithMessage(translator["Required", "FirstName"]).WithErrorCode("Required")
           .MinimumLength(2).WithMessage(translator["MinimumLength", "FirstName", "2"]).WithErrorCode("MinimumLength")
           .MaximumLength(25).WithMessage(translator["MaximumLength", "FirstName", "25"]).WithErrorCode("MaximumLength");

        RuleFor(c => c.LastName)
           .NotNull().WithMessage(translator["Required", "LastName"]).WithErrorCode("Required")
           .MinimumLength(2).WithMessage(translator["MinimumLength", "LastName", "2"]).WithErrorCode("MinimumLength")
           .MaximumLength(25).WithMessage(translator["MaximumLength", "LastName", "25"]).WithErrorCode("MaximumLength");
    }
}
