﻿using Odontio.Application.Common.Attributes;
using Odontio.Application.Common.Interfaces;
using Odontio.Application.Users.Common;

namespace Odontio.Application.Users.Commands.UpdateUser;

[RolesAuthorize(nameof(RolesEnum.Administrator))]
public class UpdateUserCommand : IRequest<ErrorOr<UpsertUserResult>>
{
    public long Id { get; set; }
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhotoUrl { get; set; }
    public long RoleId { get; set; }
    public long? WorkspaceId { get; set; }
    public bool IsDoctor { get; set; }
}