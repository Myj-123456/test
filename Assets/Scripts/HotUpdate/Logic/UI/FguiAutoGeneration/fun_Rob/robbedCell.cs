/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robbedCell : GComponent
    {
        public Controller status;
        public GTextField lb_title;
        public GGroup g_userName;
        public GTextField lb_timeDown;
        public GImage n46;
        public btn_unlock btn_unlock;
        public robbedHead_big robHead;
        public catchBtn catchBtn;
        public GLoader img_reward;
        public GImage n48;
        public GImage n51;
        public const string URL = "ui://z1on8kwdd5kwpio";

        public static robbedCell CreateInstance()
        {
            return (robbedCell)UIPackage.CreateObject("fun_Rob", "robbedCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            lb_title = (GTextField)GetChildAt(0);
            g_userName = (GGroup)GetChildAt(1);
            lb_timeDown = (GTextField)GetChildAt(2);
            n46 = (GImage)GetChildAt(3);
            btn_unlock = (btn_unlock)GetChildAt(4);
            robHead = (robbedHead_big)GetChildAt(5);
            catchBtn = (catchBtn)GetChildAt(6);
            img_reward = (GLoader)GetChildAt(7);
            n48 = (GImage)GetChildAt(8);
            n51 = (GImage)GetChildAt(9);
        }
    }
}