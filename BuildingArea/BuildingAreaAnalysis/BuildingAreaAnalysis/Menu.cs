using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPluginEngine;

namespace BuildingAreaAnalysis
{
    class Menu:IMenuDef
    {
        #region IMenuDef成员
        public string Caption
        {
            get { return "建筑用地分析"; }
        }

        public string Name
        {
            get { return "Menu"; }
        }

        public long ItemCount
        {
            get { return 1; }
        }

        public void GetItemInfo(int pos, ItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "BuildingAreaAnalysis.BuildingCmd";
                    itemDef.Group = false;
                    break;
                //case 1:
                //    itemDef.ID = "WaterAnalyasis.frmAccCmd";
                //    itemDef.Group = false;
                //    break;
                //case 2:
                //    itemDef.ID = "WaterAnalyasis.frmFillCmd";
                //    itemDef.Group = false;
                //    break;
                //case 3:
                //    itemDef.ID = "WaterAnalyasis.frmBasCmd";
                //    itemDef.Group = false;
                //    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
