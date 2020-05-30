using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Model;

namespace Project.Views.Controls
{
    public static class Filters
    {
        public static IEnumerable<MedicalAppointment> ByDate(this IEnumerable<MedicalAppointment> appointments, DateTime date)
        {
            var app = from a in appointments
                      where a.Beginning.ToShortDateString() == date.ToShortDateString()
                      select a;
            return app;
        }
    }
}
