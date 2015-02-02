using System;
using System.Collections.Generic;
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
            string fileName = String.Concat("FAA_Form_337_", ReturnedRecord.N_Number, ".pdf");
            PdfService.WriteToPdf(ReturnedRecord, fileName);
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
        }

        #endregion
    }
}
