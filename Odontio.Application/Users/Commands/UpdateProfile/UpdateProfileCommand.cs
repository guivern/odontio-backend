﻿using Odontio.Application.Common.Attributes;
using Odontio.Application.Common.Interfaces;

namespace Odontio.Application.Users.Commands.UpdateProfile;

[ValidateWorkspace]
[RolesAuthorize(nameof(RolesEnum.Administrator), nameof(RolesEnum.Doctor), nameof(RolesEnum.Assistant))]
public class UpdateProfileCommand : IRequest<ErrorOr<UpdateProfileResult>>, IWorkspaceResource
{
    public long Id { get; set; }
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhotoUrl { get; set; }
    public long WorkspaceId { get; set; }
}