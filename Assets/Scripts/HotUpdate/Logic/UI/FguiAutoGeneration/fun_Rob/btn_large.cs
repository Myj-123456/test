/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_large : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public GTextField titleLab1;
        public GImage n9;
        public GLoader pic;
        public const string URL = "ui://z1on8kwdcw741ayr8mb";

        public static btn_large CreateInstance()
        {
            return (btn_large)UIPackage.CreateObject("fun_Rob", "btn_large");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            titleLab1 = (GTextField)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
            pic = (GLoader)GetChildAt(4);
        }
    }
}