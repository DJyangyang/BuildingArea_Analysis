﻿using MyPluginEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingAreaAnalysis
{
    class BuildingCmd:MyPluginEngine.ICommand
    {
          private MyPluginEngine.IApplication hk;
        private System.Drawing.Bitmap m_hBitmap;
        private ESRI.ArcGIS.SystemUI.ICommand cmd = null;
       Form1 pfrmTable;

       public BuildingCmd()
        {
            string str = @"..\Data\Image\TrendAnalyze\line_chart.png";
            if (System.IO.File.Exists(str))
                m_hBitmap = new Bitmap(str);
            else
                m_hBitmap = null;
        }
        #region ICommand 成员
        public System.Drawing.Bitmap Bitmap
        {
            get { return m_hBitmap; }
        }

        public string Caption
        {
            get { return "建筑用地"; }
        }

        public string Category
        {
            get { return "BuildingCmd"; }
        }

        public bool Checked
        {
            get { return false; }
        }

        public bool Enabled
        {
            get { return true; }
        }

        public int HelpContextId
        {
            get { return 0; }
        }

        public string HelpFile
        {
            get { return ""; }
        }

        public string Message
        {
            get { return "建筑用地"; }
        }

        public string Name
        {
            get { return "Menu"; }
        }

        public void OnClick()
        {
            //System.Windows.Forms.MessageBox.Show("正在开发中！");
            pfrmTable = new Form1();
            pfrmTable.ShowDialog();

        }

        public void OnCreate(IApplication hook)
        {
            if (hook != null)
            {
                this.hk = hook;
                //pfrmTable = new frmTable();
                //pfrmTable.Visible = false;
            }
        }

        public string Tooltip
        {
            get { return "建筑用地"; }
        }
        #endregion

    }
    
}
