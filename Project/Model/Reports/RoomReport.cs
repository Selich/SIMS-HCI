using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;
using System.Windows;

namespace Project.Model.Reports
{
    class RoomReport : Report
    {
        public RoomReport(string path, DateTime date)
            : base(path,date,"Room")
        { }

    }
}
