/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_close : GButton
    {
        public GImage n10;
        public const string URL = "ui://z1on8kwdcw741ayr8m5";

        public static btn_close CreateInstance()
        {
            return (btn_close)UIPackage.CreateObject("fun_Rob", "btn_close");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n10 = (GImage)GetChildAt(0);
        }
    }
}