﻿using Odontio.Application.Budgets.Common;
using Odontio.Application.Common.Interfaces;

namespace Odontio.Application.Budgets.Queries.GetBudgetById;

public class GetBudgetByIdHandler(IApplicationDbContext context): IRequestHandler<GetBudgetByIdQuery, ErrorOr<GetBudgetFullResult>>
{
    public async Task<ErrorOr<GetBudgetFullResult>> Handle(GetBudgetByIdQuery request, CancellationToken cancellationToken)
    {
        var budget = await context.Budgets
            .Include(x => x.Patient)
            .Include(x => x.PatientTreatments)
            .ThenInclude(x => x.Treatment)
            .Include(x => x.Payments)
            .Where(x => x.Id == request.Id)
            .Where(x => x.PatientId == request.PatientId)
            .ProjectToType<GetBudgetFullResult>()
            .FirstOrDefaultAsync(cancellationToken);

        if (budget == null)
        {
            return Error.NotFound(description: "Budget not found.");
        }

        return budget;
    }
}