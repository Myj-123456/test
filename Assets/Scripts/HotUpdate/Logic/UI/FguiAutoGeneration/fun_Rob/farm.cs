/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class farm : GComponent
    {
        public GImage btn_itemList;
        public blueCostBtn btn_open;
        public const string URL = "ui://z1on8kwddh2tpja";

        public static farm CreateInstance()
        {
            return (farm)UIPackage.CreateObject("fun_Rob", "farm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn_itemList = (GImage)GetChildAt(0);
            btn_open = (blueCostBtn)GetChildAt(1);
        }
    }
}