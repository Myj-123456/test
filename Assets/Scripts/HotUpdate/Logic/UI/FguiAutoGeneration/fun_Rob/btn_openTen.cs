/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_openTen : GButton
    {
        public Controller button;
        public GImage n14;
        public GImage n15;
        public GTextField n12;
        public const string URL = "ui://z1on8kwdcw741ayr8m3";

        public static btn_openTen CreateInstance()
        {
            return (btn_openTen)UIPackage.CreateObject("fun_Rob", "btn_openTen");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n14 = (GImage)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            n12 = (GTextField)GetChildAt(2);
        }
    }
}