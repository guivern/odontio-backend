﻿using Odontio.Domain.Common;

namespace Odontio.Domain.Entities;

public class Appointment : BaseAuditableEntity
{
    public long Id { get; set; }
    public DateTimeOffset Date {get; set;}
    public long PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    public ICollection<MedicalNote> MedicalNotes { get; set; } = new List<MedicalNote>();
}