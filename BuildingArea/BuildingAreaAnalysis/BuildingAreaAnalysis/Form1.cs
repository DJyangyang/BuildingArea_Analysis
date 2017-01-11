using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace BuildingAreaAnalysis
{
    public partial class Form1 : Form
        
    { private string sConn = null;
        private OleDbConnection pConn = null;
        private DataTable dt = null;
        private PointPairList list1 = null, list2 = null, list3 = null, list4 = null;
        public Form1()
        {
            InitializeComponent();
        }

        

     

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            CreateMutiLineChart();
            LoadHistoryData();
        }

        private void LoadHistoryData()
        {

            while (list1.Count > 1)
            {
                list1.RemoveAt(1);
                list2.RemoveAt(1);
                list3.RemoveAt(1);
                list4.RemoveAt(1);
            }

            for (int i = 0; i < 16; i++)
            {
                Thread.Sleep(100);
                double x = double.Parse(dt.Rows[i]["year"].ToString().Trim());
                double y1 = double.Parse(dt.Rows[i]["Building"].ToString().Trim());
                double y2 = double.Parse(dt.Rows[i]["Land"].ToString().Trim());
                //double y3 = double.Parse(dt.Rows[i]["农业"].ToString().Trim());
                //double y4 = double.Parse(dt.Rows[i]["工业"].ToString().Trim());
                list1.Add(x, y1);
                list2.Add(x, y2);
                //list3.Add(x, y3);
                //list4.Add(x, y4);
                zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;

                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Refresh();
            }
        }

        private void CreateMutiLineChart()
        {
            dgDataSource1.DataSource = dt;

            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            // Set up the title and axis labels
            myPane.Title.Text = "用地需求状况";
            myPane.XAxis.Title.Text = "年份";
            myPane.YAxis.Title.Text = "需求量";


            list1 = new PointPairList();
            list2 = new PointPairList();
            list3 = new PointPairList();
            list4 = new PointPairList();



            LineItem myCurve1 = null, myCurve2 = null, myCurve3 = null, myCurve4 = null;


            myCurve1 = myPane.AddCurve("Building",
                list1, Color.Red, SymbolType.Diamond);


            myCurve2 = myPane.AddCurve("Land",
                list2, Color.Blue, SymbolType.Circle);


            //myCurve3 = myPane.AddCurve("农业",
            //    list3, Color.Green, SymbolType.Star);


            //myCurve4 = myPane.AddCurve("工业",
            //    list4, Color.Orange, SymbolType.Square);



            myPane.Title.FontSpec.FontColor = Color.Green;


            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.LightGray;
            myPane.YAxis.MajorGrid.Color = Color.LightGray;


            myPane.Legend.Position = ZedGraph.LegendPos.Bottom;


            myCurve1.Line.Width = 1.0F;
            myCurve2.Line.Width = 1.0F;
            //myCurve3.Line.Width = 1.0F;
            //myCurve4.Line.Width = 1.0F;


            myCurve1.Symbol.Size = 2.0F;
            myCurve2.Symbol.Size = 2.0F;
            //myCurve3.Symbol.Size = 2.0F;
            //myCurve4.Symbol.Size = 2.0F;

            myCurve1.Symbol.Fill = new Fill(Color.White);
            myCurve2.Symbol.Fill = new Fill(Color.White);
            //myCurve3.Symbol.Fill = new Fill(Color.White);
            //myCurve4.Symbol.Fill = new Fill(Color.White);


            myPane.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(255, 255, 210), -45F);


            TextObj myText = new TextObj("Interesting\nPoint", 230F, 70F);
            myText.FontSpec.FontColor = Color.Red;
            myText.Location.AlignH = AlignH.Center;
            myText.Location.AlignV = AlignV.Top;
            myPane.GraphObjList.Add(myText);
            ArrowObj myArrow = new ArrowObj(Color.Red, 12F, 230F, 70F, 280F, 55F);
            myPane.GraphObjList.Add(myArrow);

            myPane.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void LoadData()
        {
            //数据库名字IndustrialDV
            sConn = @"Provider = Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + @"\Data\data.mdb;Jet OLEDB:Database Password = ";
            if (pConn == null)
                pConn = new OleDbConnection(sConn);
            if (pConn.State == ConnectionState.Closed)
                pConn.Open();
            OleDbCommand cmd = pConn.CreateCommand();
            cmd.CommandText = "Select id,year,Building,Land From tb_building";
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "tb_building");
            if (dt == null)
                dt = new DataTable();
            dt = ds.Tables["tb_building"];
        }
    }
}
