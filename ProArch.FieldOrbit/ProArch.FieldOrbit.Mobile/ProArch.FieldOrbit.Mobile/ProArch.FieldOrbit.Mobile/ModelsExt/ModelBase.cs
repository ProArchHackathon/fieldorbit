// Decompiled with JetBrains decompiler
// Type: ProArch.FieldOrbit.Models.ModelBase
// Assembly: ProArch.FieldOrbit.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B85466C5-147E-4F15-95F5-F5AA47647199
// Assembly location: C:\Users\naveenh\Desktop\ProArch.FieldOrbit.Mobile\ProArch.FieldOrbit.Mobile\References\ProArch.FieldOrbit.Models.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace ProArch.FieldOrbit.Models
{
  public class ModelBase
  {
    public IEnumerable<Edit> Validate(bool throwEdit = false)
    {
      List<Edit> editsList = new List<Edit>();
      //List<ValidationResult> validationResultList = new List<ValidationResult>();
      //if (!Validator.TryValidateObject((object) this, new ValidationContext((object) this), (ICollection<ValidationResult>) validationResultList, true))
      //  validationResultList.ForEach((Action<ValidationResult>) (r => editsList.Add(new Edit()
      //  {
      //    FieldName = r.MemberNames.First<string>(),
      //    Message = r.ErrorMessage
      //  })));
      //if (throwEdit && editsList.Count > 0)
      //  throw new EditException()
      //  {
      //    Edits = (IEnumerable<Edit>) editsList
      //  };
      return (IEnumerable<Edit>) editsList;
    }

    public bool Validate()
    {
      //List<Edit> editsList = new List<Edit>();
      //List<ValidationResult> validationResultList = new List<ValidationResult>();
      //if (!Validator.TryValidateObject((object) this, new ValidationContext((object) this), (ICollection<ValidationResult>) validationResultList, true))
      //  validationResultList.ForEach((Action<ValidationResult>) (r => editsList.Add(new Edit()
      //  {
      //    FieldName = r.MemberNames.First<string>(),
      //    Message = r.ErrorMessage
      //  })));
      //if (editsList.Count > 0)
      //  throw new EditException()
      //  {
      //    Edits = (IEnumerable<Edit>) editsList
      //  };
      return true;
    }
  }
}
