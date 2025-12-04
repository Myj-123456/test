/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robbedCell : GComponent
    {
        public Controller status;
        public GImage n40;
        public GImage n41;
        public GImage n42;
        public GImage n9;
        public GTextField lb_title;
        public GGroup g_userName;
        public GTextField lb_timeDown;
        public GButton btn_unlock;
        public GComponent robHead;
        public GImage n38;
        public GButton catchBtn;
        public GLoader img_reward;
        public GTextField Vip;
        public const string URL = "ui://z1on8kwdd5kwpio";

        public static robbedCell CreateInstance()
        {
            return (robbedCell)UIPackage.CreateObject("fun_Rob", "robbedCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n40 = (GImage)GetChildAt(0);
            n41 = (GImage)GetChildAt(1);
            n42 = (GImage)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
            lb_title = (GTextField)GetChildAt(4);
            g_userName = (GGroup)GetChildAt(5);
            lb_timeDown = (GTextField)GetChildAt(6);
            btn_unlock = (GButton)GetChildAt(7);
            robHead = (GComponent)GetChildAt(8);
            n38 = (GImage)GetChildAt(9);
            catchBtn = (GButton)GetChildAt(10);
            img_reward = (GLoader)GetChildAt(11);
            Vip = (GTextField)GetChildAt(12);
        }
    }
}