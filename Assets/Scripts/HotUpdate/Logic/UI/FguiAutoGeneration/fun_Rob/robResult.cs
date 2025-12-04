/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robResult : GComponent
    {
        public Controller status;
        public Controller status_share;
        public GImage n30;
        public GTextField lb_title;
        public GButton btn_sure;
        public GLoader img_tip;
        public blueCostBtn1 btn_getReward;
        public GRichTextField txt_tip;
        public GButton close_btn;
        public blueVideoBtn2 btn_watchVideo1;
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
            n30 = (GImage)GetChildAt(0);
            lb_title = (GTextField)GetChildAt(1);
            btn_sure = (GButton)GetChildAt(2);
            img_tip = (GLoader)GetChildAt(3);
            btn_getReward = (blueCostBtn1)GetChildAt(4);
            txt_tip = (GRichTextField)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            btn_watchVideo1 = (blueVideoBtn2)GetChildAt(7);
            lb_wacthCount = (GRichTextField)GetChildAt(8);
        }
    }
}