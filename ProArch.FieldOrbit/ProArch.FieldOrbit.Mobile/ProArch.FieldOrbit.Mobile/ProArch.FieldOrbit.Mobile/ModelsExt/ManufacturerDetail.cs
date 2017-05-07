// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.ManufacturerDetail
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

using System;

namespace ProArch.FieldOrbit.Models
{
  public class ManufacturerDetail : ModelBase
  {
    public int Id { get; set; }

    public string Company { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? ExpiryDate { get; set; }
  }
}
