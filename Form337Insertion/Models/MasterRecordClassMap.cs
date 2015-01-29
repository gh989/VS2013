using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace Form337Insertion.Models
{
    class MasterRecordClassMap : CsvClassMap<MasterRecord>
    {
        public MasterRecordClassMap()
        {
            Map(m => m.n_number).Name("N-NUMBER");
            Map(m => m.serial_number).Name("SERIAL NUMBER");
            Map(m => m.mfr_mdl_code).Name("MFR MDL CODE");
            Map(m => m.eng_mfr_mdl).Name("ENG MFR MDL");
            Map(m => m.year_mfr).Name("YEAR MFR");
            Map(m => m.type_registrant).Name("TYPE REGISTRANT");
            Map(m => m.name).Name("NAME");
            Map(m => m.street).Name("STREET");
            Map(m => m.street2).Name("STREET2");
            Map(m => m.city).Name("CITY");
            Map(m => m.state).Name("STATE");
            Map(m => m.zip_code).Name("ZIP CODE");
            Map(m => m.region).Name("REGION");
            Map(m => m.county).Name("COUNTY");
            Map(m => m.country).Name("COUNTRY");
            Map(m => m.last_action_date).Name("LAST ACTION DATE");
            Map(m => m.cert_issue_date).Name("CERT ISSUE DATE");
            Map(m => m.certification).Name("CERTIFICATION");
            Map(m => m.type_aircraft).Name("TYPE AIRCRAFT");
            Map(m => m.type_engine).Name("TYPE ENGINE");
            Map(m => m.status_code).Name("STATUS CODE");
            Map(m => m.mode_s_code).Name("MODE S CODE");
            Map(m => m.fract_owner).Name("FRACT OWNER");
            Map(m => m.air_worth_date).Name("AIR WORTH DATE");
            Map(m => m.other_names1).Name("OTHER NAMES(1)");
            Map(m => m.other_names2).Name("OTHER NAMES(2)");
            Map(m => m.other_names3).Name("OTHER NAMES(3)");
            Map(m => m.other_names4).Name("OTHER NAMES(4)");
            Map(m => m.other_names5).Name("OTHER NAMES(5)");
            Map(m => m.expiration_date).Name("EXPIRATION DATE");
            Map(m => m.unique_id).Name("UNIQUE ID");
            Map(m => m.kit_mfr).Name("KIT MFR");
            Map(m => m.kit_model).Name(" KIT MODEL");
            Map(m => m.mode_s_code_hex).Name("MODE S CODE HEX");
        }
    }
}
