using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace WpfApplication1 {
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        public XtraReport1() {
            InitializeComponent();
            BeforePrint += XtraReport1_BeforePrint;
        }

        void XtraReport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            this.FilterString = @"[CategoryID] In (" + ConvertParameterValues() + ")";
        }

        private string ConvertParameterValues() {
            if(Parameters[0].Value.GetType() == typeof(System.Int32))
                return Parameters[0].Value.ToString();

            List<object> valuesList = Parameters[0].Value as List<object>;
            string FilterStringValue = String.Empty;

            if(valuesList != null) {
                for(int i = 0; i < valuesList.Count; i++) {
                    FilterStringValue += valuesList[i].ToString();
                    if(i != valuesList.Count - 1)
                        FilterStringValue += ",";
                }
            }
            return FilterStringValue;
        }
    }
}
