/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class draw_main_view : GComponent
    {
        public Controller tab;
        public Controller status;
        public GLoader bg;
        public flower_draw_view flower_draw;
        public daimond_draw_view diamond_draw_view;
        public GButton close_btn;
        public GList list;
        public GGroup n14;
        public GImage n2;
        public GTextField titleLab;
        public GButton help_btn;
        public GGroup n19;
        public const string URL = "ui://97nah3khbwsw1";

        public static draw_main_view CreateInstance()
        {
            return (draw_main_view)UIPackage.CreateObject("fun_Draw", "draw_main_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            status = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            flower_draw = (flower_draw_view)GetChildAt(1);
            diamond_draw_view = (daimond_draw_view)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
            n14 = (GGroup)GetChildAt(5);
            n2 = (GImage)GetChildAt(6);
            titleLab = (GTextField)GetChildAt(7);
            help_btn = (GButton)GetChildAt(8);
            n19 = (GGroup)GetChildAt(9);
        }
    }
}