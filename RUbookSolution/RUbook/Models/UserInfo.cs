using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace RUbook.Models
{
    public class UserInfo
    {
        public int ID { get; set; }
        public virtual ApplicationUser UserID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string DateOfBirth { get; set; }
        public string Image { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Education { get; set; }
		public string WorkInfo { get; set; }
		public string Department { get; set; }
		

        public virtual ICollection<WorkInfo> WorksInfo { get; set; }
        public virtual ICollection<EducationInfo> EducationsInfo { get; set; }

    }
}