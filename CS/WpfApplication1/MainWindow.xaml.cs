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

namespace WpfApplication1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        XtraReport1 report;
        nwindDataSet ds = new nwindDataSet();

        private void documentPreview1_Loaded(object sender, RoutedEventArgs e) {
            report = new XtraReport1() { RequestParameters = false };
            report.categoriesTableAdapter.Fill(ds.Categories);


            XtraReportPreviewModel model = new XtraReportPreviewModel();
            model.Report = report;
            model.CustomizeParameterEditors += model_CustomizeParameterEditors;
            report.CreateDocument();
            documentPreview1.Model = model;
        }

        void model_CustomizeParameterEditors(object sender, CustomizeParameterEditorsEventArgs e) {
            
            if(e.Parameter.Name == "CategoryID") {
                ComboBoxEdit editor = new ComboBoxEdit();
                editor.ItemsSource = ds.Categories;
                editor.DisplayMember = "CategoryName";
                editor.ValueMember = "CategoryID";
                editor.StyleSettings = new CheckedComboBoxStyleSettings();
                e.BoundDataMember = "EditValue";
                e.Editor = editor;
            }
            
        }
    }
}
