﻿using Odontio.Application.Common.Interfaces;

namespace Odontio.Application.Budgets.Commands.DeleteBudget;

public class DeleteBudgetHandler(IApplicationDbContext context) : IRequestHandler<DeleteBudgetCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = await context.Budgets
            .Where(x => x.PatientId == request.PatientId)
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (budget == null)
        {
            return Error.NotFound(description: "Budget not found");
        }

        context.Budgets.Remove(budget);

        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}