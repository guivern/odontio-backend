﻿using Odontio.Application.Common.Interfaces;
using Odontio.Application.MedicalConditions.UpdateMedicalCondition;

namespace Odontio.Application.MedicalConditions.Common.UpdateMedicalCondition;

public class UpdateMedicalConditionHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<UpdateMedicalConditionCommand, ErrorOr<MedicalConditionResult>>
{
    public async Task<ErrorOr<MedicalConditionResult>> Handle(UpdateMedicalConditionCommand request,
        CancellationToken cancellationToken)
    {
        var medicalCondition = await context.MedicalConditions
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.PatientId == request.PatientId, cancellationToken);
        
        if (medicalCondition == null)
        {
            return Error.NotFound(description: "Medical condition not found");
        }
        
        medicalCondition = mapper.Map(request, medicalCondition);
        
        try
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            return Error.Conflict(description: "The medical condition was modified by another user");
        }
        
        var result = mapper.Map<MedicalConditionResult>(medicalCondition);
        
        return result;
    }
}