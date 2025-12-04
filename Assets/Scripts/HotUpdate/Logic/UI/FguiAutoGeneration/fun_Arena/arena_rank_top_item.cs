/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Arena
{
    public partial class arena_rank_top_item : GComponent
    {
        public Controller rankStyle;
        public GImage n63;
        public GImage n65;
        public GImage n66;
        public GImage n53;
        public GImage n59;
        public GImage n60;
        public GImage n61;
        public GComponent iconCom;
        public GTextField txt_point;
        public GTextField txt_name;
        public const string URL = "ui://dz2e3lzav5lj1yjp7vf";

        public static arena_rank_top_item CreateInstance()
        {
            return (arena_rank_top_item)UIPackage.CreateObject("fun_Arena", "arena_rank_top_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            rankStyle = GetControllerAt(0);
            n63 = (GImage)GetChildAt(0);
            n65 = (GImage)GetChildAt(1);
            n66 = (GImage)GetChildAt(2);
            n53 = (GImage)GetChildAt(3);
            n59 = (GImage)GetChildAt(4);
            n60 = (GImage)GetChildAt(5);
            n61 = (GImage)GetChildAt(6);
            iconCom = (GComponent)GetChildAt(7);
            txt_point = (GTextField)GetChildAt(8);
            txt_name = (GTextField)GetChildAt(9);
        }
    }
}