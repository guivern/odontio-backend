﻿using Odontio.Application.Appointments.Common;
using Odontio.Application.Common.Interfaces;

namespace Odontio.Application.Appointments.Queries.GetAppointmentById;

public class GetAppointmentByIdHandler(IApplicationDbContext context)
    : IRequestHandler<GetAppointmentByIdQuery, ErrorOr<GetAppointmentResult>>
{
    public async Task<ErrorOr<GetAppointmentResult>> Handle(GetAppointmentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var appointment = await context.Appointments
            .Include(x => x.MedicalRecords)
            .ThenInclude(x => x.PatientTreatment)
            .ThenInclude(x => x.Treatment)
            .Include(x => x.Patient)
            .Where(x => x.PatientId == request.PatientId && x.Patient.WorkspaceId == request.WorkspaceId)
            .ProjectToType<GetAppointmentResult>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (appointment == null)
        {
            return Error.NotFound(description: "Appointment not found");
        }

        return appointment;
    }
}