// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.Job
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

using ProArch.FieldOrbit.Models.Enums;
using System;

namespace ProArch.FieldOrbit.Models
{
  public class Job : ModelBase
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int EstimatedDuration { get; set; }

    public JobStatus Status { get; set; }

    public JobPriority Priority { get; set; }

    public string Comments { get; set; }

    public string Observations { get; set; }

    public Employee Employee { get; set; }

    public WorkRequest WorkRequest { get; set; }

    public Timesheet Timesheet { get; set; }
  }
}
