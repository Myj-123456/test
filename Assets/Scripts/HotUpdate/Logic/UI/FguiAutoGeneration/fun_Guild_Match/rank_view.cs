/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class rank_view : GComponent
    {
        public Controller status;
        public GImage n2;
        public GLoader bg;
        public GImage n7;
        public GImage n3;
        public GImage n8;
        public GImage n9;
        public GButton close_btn;
        public GList match_list;
        public tabBtn match_btn;
        public tabBtn history_btn;
        public tabBtn people_btn;
        public match_history_item item1;
        public match_history_item item2;
        public match_history_item item3;
        public match_history_item item4;
        public my_rank_view my_rank;
        public const string URL = "ui://qefze8qir0nz2y";

        public static rank_view CreateInstance()
        {
            return (rank_view)UIPackage.CreateObject("fun_Guild_Match", "rank_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
            n8 = (GImage)GetChildAt(4);
            n9 = (GImage)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            match_list = (GList)GetChildAt(7);
            match_btn = (tabBtn)GetChildAt(8);
            history_btn = (tabBtn)GetChildAt(9);
            people_btn = (tabBtn)GetChildAt(10);
            item1 = (match_history_item)GetChildAt(11);
            item2 = (match_history_item)GetChildAt(12);
            item3 = (match_history_item)GetChildAt(13);
            item4 = (match_history_item)GetChildAt(14);
            my_rank = (my_rank_view)GetChildAt(15);
        }
    }
}