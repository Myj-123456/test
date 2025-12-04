/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class handbookLevelUpDetail : GComponent
    {
        public GImage n475;
        public GImage n474;
        public GImage n471;
        public GTextField title;
        public GList list;
        public GButton close_btn;
        public const string URL = "ui://6q8q1ai6t77cwps1";

        public static handbookLevelUpDetail CreateInstance()
        {
            return (handbookLevelUpDetail)UIPackage.CreateObject("fun_CultivationManual", "handbookLevelUpDetail");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n475 = (GImage)GetChildAt(0);
            n474 = (GImage)GetChildAt(1);
            n471 = (GImage)GetChildAt(2);
            title = (GTextField)GetChildAt(3);
            list = (GList)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
        }
    }
}