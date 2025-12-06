/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class achiev_task_view : GComponent
    {
        public GLoader bg;
        public GLoader bg1;
        public GLoader3D anim;
        public GImage n31;
        public GList achiev_list;
        public GList tab_list;
        public GGroup n64;
        public GImage n53;
        public GButton help_btn;
        public GTextField titleLab;
        public GGroup n57;
        public GImage n56;
        public GButton close_btn;
        public GGroup n58;
        public const string URL = "ui://ueo46waakelj1ayr82c";

        public static achiev_task_view CreateInstance()
        {
            return (achiev_task_view)UIPackage.CreateObject("fun_DailyTask", "achiev_task_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            anim = (GLoader3D)GetChildAt(2);
            n31 = (GImage)GetChildAt(3);
            achiev_list = (GList)GetChildAt(4);
            tab_list = (GList)GetChildAt(5);
            n64 = (GGroup)GetChildAt(6);
            n53 = (GImage)GetChildAt(7);
            help_btn = (GButton)GetChildAt(8);
            titleLab = (GTextField)GetChildAt(9);
            n57 = (GGroup)GetChildAt(10);
            n56 = (GImage)GetChildAt(11);
            close_btn = (GButton)GetChildAt(12);
            n58 = (GGroup)GetChildAt(13);
        }
    }
}