using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherForecastApplication.Models.Enums
{
    public enum ForecastTerm
    {
        [Display(Name = "Today")]
        Current = 1,

        [Display(Name = "Three days")]
        ThreeDays = 3,

        [Display(Name = "Seven days")]
        SevenDays = 7
    }
}