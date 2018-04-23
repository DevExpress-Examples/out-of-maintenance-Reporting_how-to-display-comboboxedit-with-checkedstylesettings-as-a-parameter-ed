using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1 {
    [POCOViewModel]
    public class MainWindowViewModel : ViewModelBase {
        XtraReport1 report;
        public XtraReport Report { get { return report; } }
        public nwindDataSet DataSet { get; set; }
        public DataTable Categories { get { return DataSet.Tables[0]; } }
        public MainWindowViewModel() {
            if(IsInDesignMode)
                return;
            report = new XtraReport1() { RequestParameters = false };
            DataSet = new nwindDataSet();
            report.categoriesTableAdapter.Fill(DataSet.Categories);
        }
    }
}
