// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.Customer
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

using System.Collections.Generic;

namespace ProArch.FieldOrbit.Models
{
  public class Customer : ModelBase
  {
    public int Id { get; set; }

    public Name Name { get; set; }

    public Address Address { get; set; }

    public string PrimaryContact { get; set; }

    public string SecondaryContact { get; set; }

    public string SSN { get; set; }

    public string EmailAddress { get; set; }

    public bool IsActive { get; set; }

    public IList<ServiceRequest> ServiceRequests { get; set; }
  }
}
