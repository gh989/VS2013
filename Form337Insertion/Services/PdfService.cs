using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form337Insertion.Models;
using iTextSharp.text.pdf;

namespace Form337Insertion.Services
{
    class PdfService
    {
        public static void WriteToPdf(MasterRecord record)
        {
            using (PdfReader rdr = new PdfReader(@"C:\Users\Admin\Documents\Visual Studio 2013\Projects\Form337Insertion\FAA_Form_337.pdf"))
            using (PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream("FAA_Form_337_Filled.pdf", FileMode.Create)))
            {
                stamper.AcroFields.SetField("instructions and disposition of this form This report is required by law 49 USC 44701 Failure to report can result in a civil penalty for each",
                                record.n_number);
                stamper.AcroFields.SetField("Serial No", record.serial_number);
                stamper.AcroFields.SetField("Make", record.kit_mfr);
                stamper.AcroFields.SetField("Model", record.kit_model);
                stamper.AcroFields.SetField("Name As shown on registration certificate", record.name);
                stamper.AcroFields.SetField("Address", record.street);
                stamper.AcroFields.SetField("City", record.city);
                stamper.AcroFields.SetField("State", record.state);
                stamper.AcroFields.SetField("Zip", record.zip_code);
                stamper.AcroFields.SetField("Identify with aircraft nationality and registration mark and date work completed 1", record.n_number);

                stamper.Close();
                rdr.Close();
            }
        }


    }
}
