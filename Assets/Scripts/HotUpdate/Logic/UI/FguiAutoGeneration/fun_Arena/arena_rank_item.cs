/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Arena
{
    public partial class arena_rank_item : GComponent
    {
        public Controller self;
        public Controller rankStyle;
        public GImage n55;
        public GImage n53;
        public GImage n51;
        public GComponent head;
        public GComponent frame;
        public GComponent iconCom;
        public GTextField txt_point;
        public GTextField txt_name;
        public GTextField rankTxt;
        public const string URL = "ui://dz2e3lzav5lj1yjp7ve";

        public static arena_rank_item CreateInstance()
        {
            return (arena_rank_item)UIPackage.CreateObject("fun_Arena", "arena_rank_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            self = GetControllerAt(0);
            rankStyle = GetControllerAt(1);
            n55 = (GImage)GetChildAt(0);
            n53 = (GImage)GetChildAt(1);
            n51 = (GImage)GetChildAt(2);
            head = (GComponent)GetChildAt(3);
            frame = (GComponent)GetChildAt(4);
            iconCom = (GComponent)GetChildAt(5);
            txt_point = (GTextField)GetChildAt(6);
            txt_name = (GTextField)GetChildAt(7);
            rankTxt = (GTextField)GetChildAt(8);
        }
    }
}