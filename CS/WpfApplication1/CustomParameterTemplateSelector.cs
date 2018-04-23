using DevExpress.Xpf.Printing.Parameters;
using DevExpress.Xpf.Printing.Parameters.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class CustomParameterTemplateSelector : ParameterTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var parameterModel = item as ParameterModel;
            if (parameterModel.Name == "CategoryID")
                return LookUpEditTemplate;
            return base.SelectTemplate(item, container);
        }
    }
}
