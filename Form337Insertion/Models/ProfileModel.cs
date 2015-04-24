using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form337Insertion.Models
{
    public class ProfileModel
    {
        public string ProfileName { get; set; }
        public string MechanicName { get; set; }
        public string MechanicAPNumber { get; set; }
        public string PdfInputLocation { get; set; }
        public string PdfOutputLocation { get; set; }
        public string OutputFileName { get; set; }
        public bool AppendNNumber { get; set; }
        public bool AppendCustomerName { get; set; }
        public bool AppendDate { get; set; }
    }
}
