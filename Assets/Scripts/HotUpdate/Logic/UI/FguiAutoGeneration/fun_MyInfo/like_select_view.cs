/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class like_select_view : GComponent
    {
        public Controller tab;
        public GImage n2;
        public GLoader bg;
        public GImage n17;
        public GImage n23;
        public GImage n12;
        public GLoader3D spine;
        public pageBtn2 flower_btn;
        public pageBtn2 vase_btn;
        public GButton close_btn;
        public GButton sure_btn;
        public GTextField titleLab;
        public GList flower_list;
        public GList vase_list;
        public flower_show_item item1;
        public flower_show_item item2;
        public flower_show_item item3;
        public flower_show_item item4;
        public const string URL = "ui://ehkqmfbpj9p61yjp7yx";

        public static like_select_view CreateInstance()
        {
            return (like_select_view)UIPackage.CreateObject("fun_MyInfo", "like_select_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n17 = (GImage)GetChildAt(2);
            n23 = (GImage)GetChildAt(3);
            n12 = (GImage)GetChildAt(4);
            spine = (GLoader3D)GetChildAt(5);
            flower_btn = (pageBtn2)GetChildAt(6);
            vase_btn = (pageBtn2)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            sure_btn = (GButton)GetChildAt(9);
            titleLab = (GTextField)GetChildAt(10);
            flower_list = (GList)GetChildAt(11);
            vase_list = (GList)GetChildAt(12);
            item1 = (flower_show_item)GetChildAt(13);
            item2 = (flower_show_item)GetChildAt(14);
            item3 = (flower_show_item)GetChildAt(15);
            item4 = (flower_show_item)GetChildAt(16);
        }
    }
}