/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Adventure
{
    public partial class AdventureView : GComponent
    {
        public btn_goHome btn_backHome;
        public GImage n10;
        public GTextField titleLab;
        public GButton help_btn;
        public GImage n17;
        public GImage cash_icon;
        public GTextField txt_diamond;
        public GGroup group_diamond;
        public GImage n13;
        public GImage gold_icon;
        public GTextField txt_gold;
        public GGroup group_gold;
        public GImage n21;
        public GImage water_icon;
        public GTextField txt_water;
        public GGroup group_water;
        public GImage n27;
        public GImage colorPower_icon;
        public GTextField txt_colorPower;
        public GGroup n28;
        public btn pack_btn;
        public btn arraying_btn;
        public btn power_btn;
        public GGroup n32;
        public const string URL = "ui://3yqg0b4es31r4";

        public static AdventureView CreateInstance()
        {
            return (AdventureView)UIPackage.CreateObject("fun_Adventure", "AdventureView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            btn_backHome = (btn_goHome)GetChildAt(0);
            n10 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            help_btn = (GButton)GetChildAt(3);
            n17 = (GImage)GetChildAt(4);
            cash_icon = (GImage)GetChildAt(5);
            txt_diamond = (GTextField)GetChildAt(6);
            group_diamond = (GGroup)GetChildAt(7);
            n13 = (GImage)GetChildAt(8);
            gold_icon = (GImage)GetChildAt(9);
            txt_gold = (GTextField)GetChildAt(10);
            group_gold = (GGroup)GetChildAt(11);
            n21 = (GImage)GetChildAt(12);
            water_icon = (GImage)GetChildAt(13);
            txt_water = (GTextField)GetChildAt(14);
            group_water = (GGroup)GetChildAt(15);
            n27 = (GImage)GetChildAt(16);
            colorPower_icon = (GImage)GetChildAt(17);
            txt_colorPower = (GTextField)GetChildAt(18);
            n28 = (GGroup)GetChildAt(19);
            pack_btn = (btn)GetChildAt(20);
            arraying_btn = (btn)GetChildAt(21);
            power_btn = (btn)GetChildAt(22);
            n32 = (GGroup)GetChildAt(23);
        }
    }
}