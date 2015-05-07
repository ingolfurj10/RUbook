using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.Models
{
    public class EducationInfo
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string YearGraduated { get; set; }
        public string SchoolName { get; set; }
        public string DegreeName { get; set; }

    }
}