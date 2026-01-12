/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcCollection
{
    public partial class npc_collect_view : GComponent
    {
        public Controller tapCon;
        public GImage n36;
        public GImage n40;
        public GImage n39;
        public GLoader bg;
        public GButton close_btn;
        public btn_tab_collect tabBtn_3;
        public btn_tab_collect tabBtn_2;
        public btn_tab_collect tabBtn_1;
        public GGroup n26;
        public GList list;
        public GList list2;
        public GImage n11;
        public GImage n14;
        public GImage n12;
        public GTextField txt_cost;
        public btn_search btn_search;
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
            n36 = (GImage)GetChildAt(0);
            n40 = (GImage)GetChildAt(1);
            n39 = (GImage)GetChildAt(2);
            bg = (GLoader)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            tabBtn_3 = (btn_tab_collect)GetChildAt(5);
            tabBtn_2 = (btn_tab_collect)GetChildAt(6);
            tabBtn_1 = (btn_tab_collect)GetChildAt(7);
            n26 = (GGroup)GetChildAt(8);
            list = (GList)GetChildAt(9);
            list2 = (GList)GetChildAt(10);
            n11 = (GImage)GetChildAt(11);
            n14 = (GImage)GetChildAt(12);
            n12 = (GImage)GetChildAt(13);
            txt_cost = (GTextField)GetChildAt(14);
            btn_search = (btn_search)GetChildAt(15);
            search_input_text = (GTextInput)GetChildAt(16);
            n35 = (GGroup)GetChildAt(17);
        }
    }
}