using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Ribbon;

namespace DS.OrangeAdmin.Client.UI.UserControls
{
    public class OrangeRibbonCustomControl
    {
        private DXRibbonWindow _ctx;
        private RibbonControl _ctrl;

        public OrangeRibbonCustomControl(DXRibbonWindow context)
        {
            this._ctx = context;
            InitializeUI();
        }

        private async void InitializeUI()
        {
            //_ctrl = new RibbonControl();
            //_ctrl.Controls.Add(_ctrl);
            

        }
    }
}
