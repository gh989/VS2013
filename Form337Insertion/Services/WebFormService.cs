using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Form337Insertion.Models;
using HtmlAgilityPack;

namespace Form337Insertion.Services
{
    class WebFormService
    {
        public MasterRecord RetrieveRegistrationInfo(string nNumber)
        {
            string htmlReturn = SendRequest(nNumber);
            return ParseRequest(htmlReturn, nNumber);
        }

        private string SendRequest(string nNumber)
        {
            WebRequest req = WebRequest.Create("http://www6.landings.com/cgi-bin/nph-search_nnr?pass=193800885&");
            string postData = String.Concat("nnumber=",nNumber);

            byte[] send = Encoding.Default.GetBytes(postData);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = send.Length;

            Stream sout = req.GetRequestStream();
            sout.Write(send, 0, send.Length);
            sout.Flush();
            sout.Close();

            WebResponse res = req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            string returnvalue = sr.ReadToEnd();

            return returnvalue;
        }

        private MasterRecord ParseRequest(string htmlReturn, string nNumber)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlReturn);
            HtmlNodeCollection bTags = doc.DocumentNode.SelectNodes("//b");
            int startIndex = bTags.IndexOf(bTags.FirstOrDefault(record => record.InnerText.Contains(nNumber.ToUpper())));
            int currentIndex = startIndex;

            MasterRecord masterRecord = new MasterRecord();

            masterRecord.n_number = bTags[currentIndex++].InnerText;
            masterRecord.serial_number = bTags[currentIndex++].InnerText;
            masterRecord.kit_mfr = bTags[currentIndex++].InnerText;
            masterRecord.kit_model = bTags[currentIndex++].InnerText;
            masterRecord.type_engine = bTags[currentIndex++].InnerText;
            masterRecord.eng_mfr_mdl = bTags[currentIndex++].InnerText;
            masterRecord.year_mfr = bTags[currentIndex++].InnerText;
            masterRecord.name = bTags[currentIndex++].InnerText;
            masterRecord.street = bTags[currentIndex++].InnerText;
            masterRecord.city = bTags[currentIndex++].InnerText;
            masterRecord.type_registrant = bTags[currentIndex++].InnerText;
            masterRecord.cert_issue_date = bTags[currentIndex++].InnerText;

            return masterRecord;
        }
    }
}
