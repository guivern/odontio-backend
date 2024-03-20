﻿using Odontio.Application.Common.Interfaces;
using Odontio.Domain.Enums;

namespace Odontio.Application.Patients.Commands.UpdatePatient;

public class UpdatePatientValidator : AbstractValidator<UpdatePatientCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePatientValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Patient id is required.");

        RuleFor(x => x.WorkspaceId)
            .NotEmpty()
            .WithMessage("Workspace id is required.");

        RuleFor(x => x.DocumentNumber)
            .NotEmpty()
            .WithMessage("Document number is required.")
            .MustAsync(BeUniqueDocumentNumber)
            .WithMessage(x => $"Document number {x.DocumentNumber} already exists.");

        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.DocumentNumber).MaximumLength(20);
        RuleFor(x => x.Ruc).MaximumLength(20);
        RuleFor(x => x.Address).MaximumLength(256);
        RuleFor(x => x.WorkAddress).MaximumLength(256);
        RuleFor(x => x.Email).MaximumLength(100).EmailAddress();
        RuleFor(x => x.Phone).MaximumLength(20);
        RuleFor(x => x.WorkPhone).MaximumLength(20);
        RuleFor(x => x.Observations).MaximumLength(256);
        RuleFor(x => x.Occupation).MaximumLength(48);
        RuleFor(x => x.LastDentalVisit).MaximumLength(100);
        RuleFor(x => x.ToothLossCause).MaximumLength(100);
        RuleFor(x => x.Gender).NotEmpty().Must(BeValidGender).WithMessage("Invalid gender");
        RuleFor(x => x.MaritalStatus).Must(BeValidMaritalStatus).WithMessage("Invalid marital status");
    }

    private async Task<bool> BeUniqueDocumentNumber(UpdatePatientCommand command, string arg1, CancellationToken arg2)
    {
        // validate if exists a patient with the same document number but different id
        var exists = await _context.Patients
            .AsNoTracking()
            .AnyAsync(x => x.DocumentNumber.ToLower() == command.DocumentNumber.ToLower() && x.Id != command.Id, arg2);

        return !exists;
    }

    private bool BeValidMaritalStatus(string? arg)
    {
        var result = Enum.TryParse<MaritalStatus>(arg, out _);
        return string.IsNullOrEmpty(arg) || Enum.TryParse<MaritalStatus>(arg, out _);
    }

    private bool BeValidGender(string arg1)
    {
        return Enum.TryParse<Gender>(arg1, out _);
    }
}