﻿using Odontio.Application.Common.Interfaces;

namespace Odontio.Application.Treatments.Commands.DeleteTreatment;

public class DeleteTreatmentHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteTreatmentCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteTreatmentCommand request, CancellationToken cancellationToken)
    {
        var treatment = await context.Treatments.FindAsync(request.Id);

        if (treatment is null)
        {
            return Error.NotFound(description: "Treatment not found");
        }

        context.Treatments.Remove(treatment);

        try
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            return Error.Conflict(description: "Can not delete treatment due to existing dependencies.");
        }

        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}