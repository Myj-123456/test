/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class DailyTask : GComponent
    {
        public Controller taskTab;
        public Controller tab;
        public GImage n48;
        public GLoader bg;
        public GLoader bg1;
        public GLoader3D anim;
        public GList list;
        public GList achiev_list;
        public page_btn day_btn;
        public page_btn week_btn;
        public GList tab_list;
        public GImage n31;
        public GImage n34;
        public pro_com pro_day_com;
        public GImage n35;
        public GTextField proLab;
        public GGroup n51;
        public GGroup n46;
        public GGroup n50;
        public GImage n13;
        public GImage n30;
        public GButton close_btn;
        public GButton task_btn;
        public GButton achiev_btn;
        public GGroup n44;
        public const string URL = "ui://ueo46waas23e0";

        public static DailyTask CreateInstance()
        {
            return (DailyTask)UIPackage.CreateObject("fun_DailyTask", "DailyTask");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            taskTab = GetControllerAt(0);
            tab = GetControllerAt(1);
            n48 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            bg1 = (GLoader)GetChildAt(2);
            anim = (GLoader3D)GetChildAt(3);
            list = (GList)GetChildAt(4);
            achiev_list = (GList)GetChildAt(5);
            day_btn = (page_btn)GetChildAt(6);
            week_btn = (page_btn)GetChildAt(7);
            tab_list = (GList)GetChildAt(8);
            n31 = (GImage)GetChildAt(9);
            n34 = (GImage)GetChildAt(10);
            pro_day_com = (pro_com)GetChildAt(11);
            n35 = (GImage)GetChildAt(12);
            proLab = (GTextField)GetChildAt(13);
            n51 = (GGroup)GetChildAt(14);
            n46 = (GGroup)GetChildAt(15);
            n50 = (GGroup)GetChildAt(16);
            n13 = (GImage)GetChildAt(17);
            n30 = (GImage)GetChildAt(18);
            close_btn = (GButton)GetChildAt(19);
            task_btn = (GButton)GetChildAt(20);
            achiev_btn = (GButton)GetChildAt(21);
            n44 = (GGroup)GetChildAt(22);
        }
    }
}