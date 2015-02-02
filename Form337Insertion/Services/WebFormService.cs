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
        public LandingsRecord RetrieveRegistrationInfo(string nNumber)
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

            res.Close();
            sr.Close();

            return returnvalue;
        }

        private LandingsRecord ParseRequest(string htmlReturn, string nNumber)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlReturn);
            HtmlNodeCollection bTags = doc.DocumentNode.SelectNodes("//b");
            int startIndex = bTags.IndexOf(bTags.FirstOrDefault(record => record.InnerText.Contains(nNumber.ToUpper())));
            int currentIndex = startIndex;

            LandingsRecord landingsRecord = new LandingsRecord();

            landingsRecord.N_Number = bTags[currentIndex++].InnerText;
            landingsRecord.Serial_Number = bTags[currentIndex++].InnerText;
            landingsRecord.Mfr = bTags[currentIndex++].InnerText;
            landingsRecord.Model = bTags[currentIndex++].InnerText;
            landingsRecord.Eng_Mfr = bTags[currentIndex++].InnerText;
            landingsRecord.Type_Engine = bTags[currentIndex++].InnerText;
            landingsRecord.Year_Mfr = bTags[currentIndex++].InnerText;
            landingsRecord.Name = bTags[currentIndex++].InnerText;
            landingsRecord.Street = bTags[currentIndex++].InnerText;
            landingsRecord.City = bTags[currentIndex++].InnerText;
            landingsRecord.Type_Aircraft = bTags[currentIndex++].InnerText;
            landingsRecord.Cert_Issue_Date = bTags[currentIndex++].InnerText;
            landingsRecord.Classification = bTags[currentIndex++].InnerText;
            landingsRecord.Aircraft_Category = bTags[currentIndex++].InnerText;

            landingsRecord = FixAddressFields(landingsRecord);

            return landingsRecord;
        }

        private LandingsRecord FixAddressFields(LandingsRecord record)
        {
            List<string> cityStateZip;
            cityStateZip = record.City.Split(',').ToList<string>();
            record.City = cityStateZip[0].Trim();
            record.State = cityStateZip[1].Trim();
            record.Zip_Code = cityStateZip[2].Trim();

            return record;
        }
    }
}
