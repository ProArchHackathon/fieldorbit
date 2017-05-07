// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.WorkRequest
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

using System;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.Models
{
  public class WorkRequest : ModelBase
  {
    public int WRNumber { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public string RequestedBy { get; set; }

    public DateTime? EndDate { get; set; }

    public string Status { get; set; }

    public ServiceRequest ServiceRequest { get; set; }

    public Customer Customer { get; set; }

    public List<Job> Jobs { get; set; }
  }
}
