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
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Editors;
using DevExpress.XtraReports.UI;
using System.Data;

namespace WpfApplication1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void documentPreview1_Loaded(object sender, RoutedEventArgs e) {

            DataContext = new MainWindowViewModel(new XtraReport1() { RequestParameters = false });
        }


        public class MainWindowViewModel {
            public XtraReportPreviewModel ReportModel { get; set; }
            public nwindDataSet DataSet { get; set; }
            public DataTable Categories { get { return DataSet.Tables[0]; } }
            public MainWindowViewModel(XtraReport report)
            {
                DataSet = new nwindDataSet();
                
                ReportModel = new XtraReportPreviewModel();
                ReportModel.Report = report;

                (report as XtraReport1).categoriesTableAdapter.Fill(DataSet.Categories);
                report.CreateDocument(false);
            }
        }
    }
}
