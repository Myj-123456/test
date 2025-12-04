/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class PlotWindow : GComponent
    {
        public PlotScrollPanel plotScollPanel;
        public GTextField txt_goOn;
        public GButton btn_end;
        public Btn_skip btn_skip;
        public const string URL = "ui://vucpfjl8rqny4";

        public static PlotWindow CreateInstance()
        {
            return (PlotWindow)UIPackage.CreateObject("fun_Plot", "PlotWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            plotScollPanel = (PlotScrollPanel)GetChildAt(0);
            txt_goOn = (GTextField)GetChildAt(1);
            btn_end = (GButton)GetChildAt(2);
            btn_skip = (Btn_skip)GetChildAt(3);
        }
    }
}