// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.Device
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

using System;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.Models
{
  public class Device : ModelBase
  {
    public int Id { get; set; }

    public int ModelNumber { get; set; }

    public string Type { get; set; }

    public Decimal Cost { get; set; }

    public int PurchaseYear { get; set; }

    public ManufacturerDetail ManufactureDetail { get; set; }

    public string PastHistory { get; set; }

    public List<DeviceModel> DeviceModels { get; set; }
  }
}
