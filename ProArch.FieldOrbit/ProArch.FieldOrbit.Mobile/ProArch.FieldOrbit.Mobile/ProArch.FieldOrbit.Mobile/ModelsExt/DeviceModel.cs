// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.DeviceModel
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

using ProArch.FieldOrbit.Models.Enums;

namespace ProArch.FieldOrbit.Models
{
  public class DeviceModel : ModelBase
  {
    public DeviceModelType Type { get; set; }

    public ContentPath Path { get; set; }

    public bool IsRecommended { get; set; }

    public Device Device { get; set; }

    public Employee UploadedBy { get; set; }
  }
}
