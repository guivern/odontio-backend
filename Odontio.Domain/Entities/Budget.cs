﻿using Odontio.Domain.Common;
using Odontio.Domain.Enums;

namespace Odontio.Domain.Entities;

public class Budget: BaseAuditableEntity
{
    // private const int ExpirationMonths = 6;
    public long Id { get; set; }
    public DateOnly Date { get; set; }
    public BudgetStatus Status { get; set; }

    public DateOnly ExpirationDate { get; set; } /*DateOnly.FromDateTime(DateTimeOffset.Now.AddMonths(ExpirationMonths).Date);*/
    
    public long PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    
    public ICollection<PatientTreatment> PatientTreatments { get; set; } = new List<PatientTreatment>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    
    public void UpdateStatus()
    {
        if (HasAppointment())
        {
            Status = BudgetStatus.Aprobado;
        }
        else if (HasExpired())
        {
            Status = BudgetStatus.Expirado;
        }
        else
        {
            Status = BudgetStatus.Pendiente;
        }
    }
    
    public bool CanBeDeleted()
    {
        // Un Budget sólo puede ser eliminado si no tiene citas ni pagos asociados
        return !PatientTreatments.Any(x => x.Appointments.Count > 0) && Payments.Count == 0;
    }
    
    private bool HasAppointment()
    {
        return PatientTreatments.Any(x => x.Appointments.Count > 0);
    }
    
    private bool HasExpired()
    {
        return Status == BudgetStatus.Pendiente && DateOnly.FromDateTime(DateTimeOffset.Now.Date) > ExpirationDate;
    }
}