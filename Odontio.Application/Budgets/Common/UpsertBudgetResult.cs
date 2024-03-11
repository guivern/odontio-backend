﻿namespace Odontio.Application.Budgets.Common;

public class UpsertBudgetResult
{
    public long Id { get; set; }
    public DateOnly Date { get; set; }
    public string Status { get; set; } = null!;
    public DateOnly ExpirationDate { get; set; }
    public long PatientId { get; set; }
    
    public List<UpsertPatientTreatmentResult> PatientTreatments { get; set; } = new();
}

public class UpsertPatientTreatmentResult
{
    public long Id { get; set; }
    public long TreatmentId { get; set; }
    public long? ToothId { get; set; }
    public decimal Cost { get; set; }
}