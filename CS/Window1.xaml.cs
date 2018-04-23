using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.ComponentModel;

namespace WpfGridScrollbar
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            gridControl1.DataSource = ManualDataSet.CreateData().Tables[0];
            gridControl1.PopulateColumns();
        }
    }


    public class ManualDataSet : DataSet
    {
        public ManualDataSet()
            : base()
        {
            DataTable table = new DataTable("table");

            DataSetName = "ManualDataSet";

            table.Columns.Add("ID", typeof(Int32));
            table.Columns.Add("MyDateTime", typeof(DateTime));
            table.Columns.Add("MyRow", typeof(string));
            table.Columns.Add("MyData", typeof(double));
            table.Constraints.Add("IDPK", table.Columns["ID"], true);

            Tables.AddRange(new DataTable[] { table });
        }

        public static ManualDataSet CreateData()
        {
            ManualDataSet ds = new ManualDataSet();
            DataTable table = ds.Tables["table"];
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10000; i++)
            {
                table.Rows.Add(new object[] { i, DateTime.Today.AddHours(i), (i % 2 == 0 ? "A" : "B"), Math.Round(rnd.NextDouble() * 100, 2) });
            }

            return ds;
        }

        #region Disable Serialization for Tables and Relations
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get { return base.Tables; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations
        {
            get { return base.Relations; }
        }
        #endregion Disable Serialization for Tables and Relations
    }
        

}
