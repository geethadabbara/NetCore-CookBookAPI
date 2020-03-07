using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookAPI.Domain.Models
{
    public enum EUnitOfMeasurement : byte
    {
        [Description("UN")]
        Cup = 1,

        [Description("MG")]
        Milligram = 2,

        [Description("G")]
        Gram = 3,

        [Description("KG")]
        Kilogram = 4,

        [Description("ML")]
        MilliLiter = 5,

        [Description("No")]
        Number = 6
    }
}
