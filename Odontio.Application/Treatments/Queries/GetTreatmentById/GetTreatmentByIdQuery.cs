﻿using Microsoft.AspNetCore.Mvc;
using Odontio.Application.Common.Attributes;
using Odontio.Application.Common.Helpers;
using Odontio.Application.Common.Interfaces;
using Odontio.Domain.Enums;

namespace Odontio.Application.Treatments.Queries.GetTreatmentById;

[ValidateWorkspace]
[RolesAuthorize(nameof(Roles.User), nameof(Roles.Administrator))]
public class GetTreatmentByIdQuery: PagedListQueryBase, IRequest<ErrorOr<GetTreatmentByIdResult>>, IWorkspaceResource
{
    public long Id { get; init; }
    public long WorkspaceId { get; init; }
}