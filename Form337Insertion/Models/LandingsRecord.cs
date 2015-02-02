using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common.Infrastructure;

namespace Form337Insertion.Models
{
    class LandingsRecord : ObservableObject
    {
        #region Private Fields

        private string _n_number;
        private string _serial_number;
        private string _mfr;
        private string _model;
        private string _eng_mfr;
        private string _type_engine;
        private string _year_mfr;
        private string _name;
        private string _street;
        private string _street2;
        private string _city;
        private string _state;
        private string _zip_code;
        private string _type_aircraft;
        private string _cert_issue_date;
        private string _classification;
        private string _aircraft_category;

        #endregion

        #region Public Properties

        public string N_Number
        {
            get { return _n_number; }
            set { _n_number = value; RaisePropertyChanged("N_Number"); }
        }

        public string Serial_Number
        {
            get { return _serial_number; }
            set { _serial_number = value; RaisePropertyChanged("Serial_Number"); }
        }

        public string Mfr
        {
            get { return _mfr; }
            set { _mfr = value; RaisePropertyChanged("Mfr"); }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; RaisePropertyChanged("Model"); }
        }

        public string Eng_Mfr
        {
            get { return _eng_mfr; }
            set { _eng_mfr = value; RaisePropertyChanged("Eng_Mfr"); }
        }

        public string Type_Engine
        {
            get { return _type_engine; }
            set { _type_engine = value; RaisePropertyChanged("Type_Engine"); }
        }

        public string Year_Mfr
        {
            get { return _year_mfr; }
            set { _year_mfr = value; RaisePropertyChanged("Year_Mfr"); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("Name"); }
        }

        public string Street
        {
            get { return _street; }
            set { _street = value; RaisePropertyChanged("Street"); }
        }

        public string Street2
        {
            get { return _street2; }
            set { _street2 = value; RaisePropertyChanged("Street2"); }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; RaisePropertyChanged("City"); }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; RaisePropertyChanged("State"); }
        }

        public string Zip_Code
        {
            get { return _zip_code; }
            set { _zip_code = value; RaisePropertyChanged("Zip_Code"); }
        }

        public string Type_Aircraft
        {
            get { return _type_aircraft; }
            set { _type_aircraft = value; RaisePropertyChanged("Type_Aircraft"); }
        }

        public string Cert_Issue_Date
        {
            get { return _cert_issue_date; }
            set { _cert_issue_date = value; RaisePropertyChanged("Cert_Issue_Date"); }
        }

        public string Classification
        {
            get { return _classification; }
            set { _classification = value; RaisePropertyChanged("Classification"); }
        }

        public string Aircraft_Category
        {
            get { return _aircraft_category; }
            set { _aircraft_category = value; RaisePropertyChanged("Aircraft_Category"); }
        }

        #endregion
    }
}
