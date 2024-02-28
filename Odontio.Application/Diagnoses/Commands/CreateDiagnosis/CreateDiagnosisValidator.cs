﻿namespace Odontio.Application.Diagnoses.Commands.CreateDiagnosis;

public class CreateDiagnosisValidator: AbstractValidator<CreateDiagnosisCommand>
{
    public CreateDiagnosisValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.PatientId).NotEmpty();
        RuleFor(x => x.WorkspaceId).NotEmpty();
    }
}