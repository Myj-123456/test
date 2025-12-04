/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class BestLevelListItem : GComponent
    {
        public Controller level_bg;
        public GImage n13;
        public GTextField txt_count;
        public GTextField txt_touch;
        public GTextField txt_exchange;
        public GTextField txt_additional;
        public const string URL = "ui://fteyf9nzg3sj1yjp7tl";

        public static BestLevelListItem CreateInstance()
        {
            return (BestLevelListItem)UIPackage.CreateObject("fun_Friends", "BestLevelListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            level_bg = GetControllerAt(0);
            n13 = (GImage)GetChildAt(0);
            txt_count = (GTextField)GetChildAt(1);
            txt_touch = (GTextField)GetChildAt(2);
            txt_exchange = (GTextField)GetChildAt(3);
            txt_additional = (GTextField)GetChildAt(4);
        }
    }
}