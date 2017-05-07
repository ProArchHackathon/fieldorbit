// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.Timesheet
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

using System;

namespace ProArch.FieldOrbit.Models
{
  public class Timesheet : ModelBase
  {
    public int CrewId { get; set; }

    public Job Job { get; set; }

    public Customer Customer { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime WorkDate { get; set; }

    public int Hours { get; set; }

    public int Minutes { get; set; }

    public int Seconds { get; set; }

    public string Comments { get; set; }
  }
}
