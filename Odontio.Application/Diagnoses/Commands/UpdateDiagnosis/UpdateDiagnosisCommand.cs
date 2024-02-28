﻿using Odontio.Application.Common.Attributes;
using Odontio.Application.Common.Interfaces;
using Odontio.Application.Diagnoses.Common;

namespace Odontio.Application.Diagnoses.Commands.UpdateDiagnosis;

[ValidateWorkspace]
[ValidatePatient]
[RolesAuthorize(nameof(RolesEnum.Administrator))]
public class UpdateDiagnosisCommand: IRequest<ErrorOr<UpsertDiagnosisResult>>, IPatientResource
{
    public long WorkspaceId { get; set; }
    public long PatientId { get; set; }
    public long Id { get; set; }
    public DateOnly Date { get; set; }
    public long? ToothId { get; set; }
    public string Description { get; set; } = null!;
    public string? Observations { get; set; }
}