/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcCollection
{
    public partial class npc_collect_view : GComponent
    {
        public Controller tapCon;
        public GLoader bg;
        public GImage n31;
        public GList list;
        public GImage n18;
        public GImage n23;
        public GImage n24;
        public GButton tabBtn_3;
        public GButton tabBtn_2;
        public GButton tabBtn_1;
        public GGroup n26;
        public GImage n30;
        public GImage n34;
        public GLoader3D spine;
        public GImage n33;
        public GImage n4;
        public GImage n11;
        public GImage n14;
        public GImage n12;
        public GTextField title_txt;
        public GTextField txt_cost;
        public GButton btn_search;
        public GButton close_btn;
        public GTextInput search_input_text;
        public GGroup n35;
        public const string URL = "ui://ydpeia1vu0i3a";

        public static npc_collect_view CreateInstance()
        {
            return (npc_collect_view)UIPackage.CreateObject("fun_NpcCollection", "npc_collect_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tapCon = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n31 = (GImage)GetChildAt(1);
            list = (GList)GetChildAt(2);
            n18 = (GImage)GetChildAt(3);
            n23 = (GImage)GetChildAt(4);
            n24 = (GImage)GetChildAt(5);
            tabBtn_3 = (GButton)GetChildAt(6);
            tabBtn_2 = (GButton)GetChildAt(7);
            tabBtn_1 = (GButton)GetChildAt(8);
            n26 = (GGroup)GetChildAt(9);
            n30 = (GImage)GetChildAt(10);
            n34 = (GImage)GetChildAt(11);
            spine = (GLoader3D)GetChildAt(12);
            n33 = (GImage)GetChildAt(13);
            n4 = (GImage)GetChildAt(14);
            n11 = (GImage)GetChildAt(15);
            n14 = (GImage)GetChildAt(16);
            n12 = (GImage)GetChildAt(17);
            title_txt = (GTextField)GetChildAt(18);
            txt_cost = (GTextField)GetChildAt(19);
            btn_search = (GButton)GetChildAt(20);
            close_btn = (GButton)GetChildAt(21);
            search_input_text = (GTextInput)GetChildAt(22);
            n35 = (GGroup)GetChildAt(23);
        }
    }
}