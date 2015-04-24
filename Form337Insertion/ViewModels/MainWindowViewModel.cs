using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acme.Common.Infrastructure;
using Form337Insertion.Models;
using Form337Insertion.Services;

namespace Form337Insertion.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        #region Private Fields

        private ProfileModel profile;
        private string _nNumberToSearch;
        private LandingsRecord _returnedRecord;
        private WebFormService _webFormService;
        private string _makeModel;
        private string _cityStateZip;

        #endregion

        #region Public Properties

        public string NNumberToSearch
        {
            get { return _nNumberToSearch; }
            set { _nNumberToSearch = value; RaisePropertyChanged("NNumberToSearch"); }
        }

        public LandingsRecord ReturnedRecord
        {
            get { return _returnedRecord; }
            set { _returnedRecord = value; RaisePropertyChanged("ReturnedRecord"); }
        }

        public string MakeModel
        {
            get { return _makeModel; }
            set { _makeModel = value; RaisePropertyChanged("MakeModel"); }
        }

        public string CityStateZip
        {
            get { return _cityStateZip; }
            set { _cityStateZip = value; RaisePropertyChanged("CityStateZip"); }
        }

        #endregion

        #region Commands

        public ICommand LoadInfoCommand
        {
            get { return new RelayCommand(LoadInfoExecute, CanLoadInfoExecute); }
        }

        public ICommand FillPdfCommand
        {
            get { return new RelayCommand(FillPdfExecute, CanFillPdfExecute); }
        }

        #endregion

        #region Command Actions

        private void LoadInfoExecute()
        {
            ReturnedRecord = _webFormService.RetrieveRegistrationInfo(NNumberToSearch);
            MakeModel = String.Concat(ReturnedRecord.Mfr, " ", ReturnedRecord.Model);
            CityStateZip = String.Concat(ReturnedRecord.City, ", ", ReturnedRecord.State, " ", ReturnedRecord.Zip_Code);
        }

        private void FillPdfExecute()
        {
            string outputPathFile = Path.Combine(profile.PdfOutputLocation, BuildFileName());
            PdfService.WriteToPdf(ReturnedRecord, profile.PdfInputLocation, outputPathFile);
        }

        private string BuildFileName()
        {
            StringBuilder fileName = new StringBuilder(Path.GetFileNameWithoutExtension(profile.OutputFileName));
            if (profile.AppendNNumber)
                fileName.Append(" " + ReturnedRecord.N_Number);
            if (profile.AppendCustomerName)
                fileName.Append(" " + ReturnedRecord.Name);
            if (profile.AppendDate)
                fileName.Append(" " + DateTime.Today.ToString("yyyy-MM-dd"));

            return Path.ChangeExtension(fileName.ToString(), ".pdf");
        }

        #endregion

        #region Command Can Execute

        private bool CanLoadInfoExecute()
        {
            return !String.IsNullOrWhiteSpace(NNumberToSearch);
        }

        private bool CanFillPdfExecute()
        {
            return ReturnedRecord != null;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Load

        public MainWindowViewModel()
        {
            _webFormService = new WebFormService();
            profile = new ProfileModel();

            //profile.MechanicName = "Joe Bagadoughnuts";
            //profile.MechanicAPNumber = "0123456789";
            //profile.PdfInputLocation = @"FAA_Form_337.pdf";
            //profile.PdfOutputLocation = "";
            //profile.OutputFileName = "FAA_Form_337.pdf";
            //profile.AppendNNumber = true;

            //ProfileService.SaveProfile(profile, @"DefaultProfile.xml");

            profile = ProfileService.LoadFileIntoProfile("DefaultProfile.xml");

        }

        #endregion
    }
}
