using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Form337Insertion.Models;
using Form337Insertion.Services;

namespace Form337Insertion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WebFormService _service = new WebFormService();
            MasterRecord record = _service.RetrieveRegistrationInfo("4868E");
            PdfService.WriteToPdf(record);
        }
    }
}
