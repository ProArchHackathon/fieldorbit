// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.Employee
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

namespace ProArch.FieldOrbit.Models
{
  public class Employee : ModelBase
  {
    public int Id { get; set; }

    public Name Name { get; set; }

    public Address Address { get; set; }

    public string EmailAddress { get; set; }

    public bool IsActive { get; set; }

    public string SSN { get; set; }

    public string PhoneNumber { get; set; }

    public string VoiceCallUserId { get; set; }
  }
}
