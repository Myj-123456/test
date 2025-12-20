/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_unlock : GButton
    {
        public GImage n10;
        public GTextField titleLab;
        public GImage n11;
        public const string URL = "ui://z1on8kwdoa1p1ayr8m0";

        public static btn_unlock CreateInstance()
        {
            return (btn_unlock)UIPackage.CreateObject("fun_Rob", "btn_unlock");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n10 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n11 = (GImage)GetChildAt(2);
        }
    }
}