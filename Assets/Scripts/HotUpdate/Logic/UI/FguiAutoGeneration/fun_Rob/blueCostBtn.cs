/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class blueCostBtn : GButton
    {
        public GImage n6;
        public GLoader pic;
        public GTextField titleLab;
        public const string URL = "ui://z1on8kwdc60e1ayr883";

        public static blueCostBtn CreateInstance()
        {
            return (blueCostBtn)UIPackage.CreateObject("fun_Rob", "blueCostBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}