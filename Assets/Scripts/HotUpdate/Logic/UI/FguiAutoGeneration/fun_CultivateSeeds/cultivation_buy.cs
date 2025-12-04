/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class cultivation_buy : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n4;
        public GImage n6;
        public GList list;
        public GButton close_btn;
        public GTextField title;
        public GTextField tipLab;
        public GButton goBtn;
        public GButton buyBtn;
        public const string URL = "ui://udmgdnw2s23ey";

        public static cultivation_buy CreateInstance()
        {
            return (cultivation_buy)UIPackage.CreateObject("fun_CultivateSeeds", "cultivation_buy");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            list = (GList)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            title = (GTextField)GetChildAt(6);
            tipLab = (GTextField)GetChildAt(7);
            goBtn = (GButton)GetChildAt(8);
            buyBtn = (GButton)GetChildAt(9);
        }
    }
}