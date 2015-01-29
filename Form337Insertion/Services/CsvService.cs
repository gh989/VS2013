using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Form337Insertion.Models;

namespace Form337Insertion.Services
{
    class CsvService
    {
        public void ReadAllRecords()
        {
            using (StreamReader reader = File.OpenText(@"D:\Documents\Projects\Form337Insertion\AR112014\MASTER.txt"))
            {
                CsvConfiguration config = new CsvConfiguration();
                config.RegisterClassMap<MasterRecordClassMap>();
                var csv = new CsvReader(reader, config);
                var records = csv.GetRecords<MasterRecord>().ToList();
            }
        }
    }
}
