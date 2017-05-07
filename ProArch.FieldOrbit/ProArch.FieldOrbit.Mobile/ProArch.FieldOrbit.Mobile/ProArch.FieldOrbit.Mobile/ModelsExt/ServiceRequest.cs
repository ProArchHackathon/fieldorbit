// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.ServiceRequest
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

using ProArch.FieldOrbit.Models.Enums;
using System;

namespace ProArch.FieldOrbit.Models
{
  public class ServiceRequest : ModelBase
  {
    public int SRNumber { get; set; }

    public DateTime CreatedDate { get; set; }

    public ServiceType ServiceType { get; set; }

    public RequestType RequestType { get; set; }

    public Decimal Fees { get; set; }

    public DateTime? ClosedDate { get; set; }

    public string RequestedBy { get; set; }

    public string Location { get; set; }

    public string Status { get; set; }

    public Device Device { get; set; }

    public Customer Customer { get; set; }

    public Employee ClosedBy { get; set; }

    public WorkRequest WorkRequest { get; set; }
  }
}
