/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_open : GButton
    {
        public GImage n8;
        public GTextField titleLab;
        public GTextField titleLab1;
        public GImage n10;
        public const string URL = "ui://z1on8kwdcw741ayr8m1";

        public static btn_open CreateInstance()
        {
            return (btn_open)UIPackage.CreateObject("fun_Rob", "btn_open");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n8 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            titleLab1 = (GTextField)GetChildAt(2);
            n10 = (GImage)GetChildAt(3);
        }
    }
}