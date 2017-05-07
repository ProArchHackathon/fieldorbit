// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.EditException
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

using System;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.Models
{
  public class EditException : Exception
  {
    public IEnumerable<Edit> Edits { get; set; }

    public EditException()
    {
    }

    public EditException(string editMessage)
      : base(editMessage)
    {
    }

    public EditException(string editMessage, Exception ex)
      : base(editMessage, ex)
    {
    }
  }
}
