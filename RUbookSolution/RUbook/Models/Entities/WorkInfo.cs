using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.Models
{
    public class WorkInfo
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string YearStart { get; set; }
        public string YearEnd { get; set; }
        public string Copmpany { get; set; }
        public string JopDescription { get; set; }
    }
}