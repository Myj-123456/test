/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class daily_task_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GLoader bg1;
        public GLoader3D anim;
        public page_btn day_btn;
        public page_btn week_btn;
        public GImage n31;
        public GList list;
        public GImage n34;
        public pro_com pro_day_com;
        public GImage n35;
        public GTextField proLab;
        public GGroup n64;
        public GGroup n63;
        public GImage n53;
        public GButton help_btn;
        public GTextField titleLab;
        public GGroup n57;
        public GImage n56;
        public GButton close_btn;
        public GGroup n58;
        public const string URL = "ui://ueo46waakelj1ayr820";

        public static daily_task_view CreateInstance()
        {
            return (daily_task_view)UIPackage.CreateObject("fun_DailyTask", "daily_task_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            anim = (GLoader3D)GetChildAt(2);
            day_btn = (page_btn)GetChildAt(3);
            week_btn = (page_btn)GetChildAt(4);
            n31 = (GImage)GetChildAt(5);
            list = (GList)GetChildAt(6);
            n34 = (GImage)GetChildAt(7);
            pro_day_com = (pro_com)GetChildAt(8);
            n35 = (GImage)GetChildAt(9);
            proLab = (GTextField)GetChildAt(10);
            n64 = (GGroup)GetChildAt(11);
            n63 = (GGroup)GetChildAt(12);
            n53 = (GImage)GetChildAt(13);
            help_btn = (GButton)GetChildAt(14);
            titleLab = (GTextField)GetChildAt(15);
            n57 = (GGroup)GetChildAt(16);
            n56 = (GImage)GetChildAt(17);
            close_btn = (GButton)GetChildAt(18);
            n58 = (GGroup)GetChildAt(19);
        }
    }
}