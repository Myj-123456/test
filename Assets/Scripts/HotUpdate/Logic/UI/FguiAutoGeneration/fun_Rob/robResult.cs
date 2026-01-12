/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robResult : GComponent
    {
        public Controller status;
        public Controller status_share;
        public GLoader bg;
        public GImage n32;
        public GTextField lb_title;
        public GButton btn_sure;
        public GLoader img_tip;
        public GButton btn_getReward;
        public GRichTextField txt_tip;
        public GButton close_btn;
        public GButton btn_watchVideo1;
        public GRichTextField lb_wacthCount;
        public const string URL = "ui://z1on8kwdqqn4pkv";

        public static robResult CreateInstance()
        {
            return (robResult)UIPackage.CreateObject("fun_Rob", "robResult");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            status_share = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            n32 = (GImage)GetChildAt(1);
            lb_title = (GTextField)GetChildAt(2);
            btn_sure = (GButton)GetChildAt(3);
            img_tip = (GLoader)GetChildAt(4);
            btn_getReward = (GButton)GetChildAt(5);
            txt_tip = (GRichTextField)GetChildAt(6);
            close_btn = (GButton)GetChildAt(7);
            btn_watchVideo1 = (GButton)GetChildAt(8);
            lb_wacthCount = (GRichTextField)GetChildAt(9);
        }
    }
}