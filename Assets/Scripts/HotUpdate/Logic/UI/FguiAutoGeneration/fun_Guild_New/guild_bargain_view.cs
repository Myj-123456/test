/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_bargain_view : GComponent
    {
        public Controller type;
        public GLoader bg3;
        public GLoader3D spine;
        public GLoader bg1;
        public GLoader bg2;
        public GLoader bg;
        public GImage n8;
        public GImage n13;
        public GImage n19;
        public GList list;
        public GImage n32;
        public GTextField decLab;
        public GTextField discount_num;
        public GTextField original_num;
        public GTextField n18;
        public GTextField bargin_num;
        public GTextField price_txt;
        public GTextField titile_txt;
        public GRichTextField bargainLab;
        public GButton close_btn;
        public GLoader costImg;
        public GButton bargain_btn;
        public GButton show_btn;
        public GList rewardList;
        public const string URL = "ui://qz6135j3s62s1yjp7yy";

        public static guild_bargain_view CreateInstance()
        {
            return (guild_bargain_view)UIPackage.CreateObject("fun_Guild_New", "guild_bargain_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            bg3 = (GLoader)GetChildAt(0);
            spine = (GLoader3D)GetChildAt(1);
            bg1 = (GLoader)GetChildAt(2);
            bg2 = (GLoader)GetChildAt(3);
            bg = (GLoader)GetChildAt(4);
            n8 = (GImage)GetChildAt(5);
            n13 = (GImage)GetChildAt(6);
            n19 = (GImage)GetChildAt(7);
            list = (GList)GetChildAt(8);
            n32 = (GImage)GetChildAt(9);
            decLab = (GTextField)GetChildAt(10);
            discount_num = (GTextField)GetChildAt(11);
            original_num = (GTextField)GetChildAt(12);
            n18 = (GTextField)GetChildAt(13);
            bargin_num = (GTextField)GetChildAt(14);
            price_txt = (GTextField)GetChildAt(15);
            titile_txt = (GTextField)GetChildAt(16);
            bargainLab = (GRichTextField)GetChildAt(17);
            close_btn = (GButton)GetChildAt(18);
            costImg = (GLoader)GetChildAt(19);
            bargain_btn = (GButton)GetChildAt(20);
            show_btn = (GButton)GetChildAt(21);
            rewardList = (GList)GetChildAt(22);
        }
    }
}