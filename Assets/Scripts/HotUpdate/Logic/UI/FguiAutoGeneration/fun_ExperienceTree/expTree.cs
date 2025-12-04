/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ExperienceTree
{
    public partial class expTree : GComponent
    {
        public Controller status;
        public GImage n4;
        public GImage n5;
        public GImage n33;
        public GImage n6;
        public GImage n24;
        public GImage n8;
        public GImage n21;
        public GButton helpBtn;
        public GList list_task;
        public GButton btnSure;
        public GTextField txt_title;
        public order_progress progress;
        public GRichTextField txt_treeLv;
        public GTextField txt_tip;
        public GTextField lb_tip;
        public GImage n26;
        public GTextField expGot;
        public GGroup n28;
        public GButton n29;
        public GButton n30;
        public GTextField timeKeep;
        public GImage n31;
        public GTextField addLab;
        public GGroup vip;
        public GGroup n36;
        public const string URL = "ui://w2l4gzffqhebi";

        public static expTree CreateInstance()
        {
            return (expTree)UIPackage.CreateObject("fun_ExperienceTree", "expTree");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            n33 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            n24 = (GImage)GetChildAt(4);
            n8 = (GImage)GetChildAt(5);
            n21 = (GImage)GetChildAt(6);
            helpBtn = (GButton)GetChildAt(7);
            list_task = (GList)GetChildAt(8);
            btnSure = (GButton)GetChildAt(9);
            txt_title = (GTextField)GetChildAt(10);
            progress = (order_progress)GetChildAt(11);
            txt_treeLv = (GRichTextField)GetChildAt(12);
            txt_tip = (GTextField)GetChildAt(13);
            lb_tip = (GTextField)GetChildAt(14);
            n26 = (GImage)GetChildAt(15);
            expGot = (GTextField)GetChildAt(16);
            n28 = (GGroup)GetChildAt(17);
            n29 = (GButton)GetChildAt(18);
            n30 = (GButton)GetChildAt(19);
            timeKeep = (GTextField)GetChildAt(20);
            n31 = (GImage)GetChildAt(21);
            addLab = (GTextField)GetChildAt(22);
            vip = (GGroup)GetChildAt(23);
            n36 = (GGroup)GetChildAt(24);
        }
    }
}