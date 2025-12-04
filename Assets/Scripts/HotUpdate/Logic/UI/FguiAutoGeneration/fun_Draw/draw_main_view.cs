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
        public GButton close_btn;
        public GList list;
        public GGroup n14;
        public GImage n2;
        public GImage n3;
        public GButton help_btn;
        public GGroup n16;
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
            close_btn = (GButton)GetChildAt(2);
            list = (GList)GetChildAt(3);
            n14 = (GGroup)GetChildAt(4);
            n2 = (GImage)GetChildAt(5);
            n3 = (GImage)GetChildAt(6);
            help_btn = (GButton)GetChildAt(7);
            n16 = (GGroup)GetChildAt(8);
        }
    }
}