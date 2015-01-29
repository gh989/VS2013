using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form337Insertion.Models
{
    public class MasterRecord
    {
        public string n_number { get; set; }
        public string serial_number { get; set; }
        public string mfr_mdl_code { get; set; }
        public string eng_mfr_mdl { get; set; }
        public string year_mfr { get; set; }
        public string type_registrant { get; set; }
        public string name { get; set; }
        public string street { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        public string region { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public string last_action_date { get; set; }
        public string cert_issue_date { get; set; }
        public string certification { get; set; }
        public string type_aircraft { get; set; }
        public string type_engine { get; set; }
        public string status_code { get; set; }
        public string mode_s_code { get; set; }
        public string fract_owner { get; set; }
        public string air_worth_date { get; set; }
        public string other_names1 { get; set; }
        public string other_names2 { get; set; }
        public string other_names3 { get; set; }
        public string other_names4 { get; set; }
        public string other_names5 { get; set; }
        public string expiration_date { get; set; }
        public string unique_id { get; set; }
        public string kit_mfr { get; set; }
        public string kit_model { get; set; }
        public string mode_s_code_hex { get; set; }
    }
}
