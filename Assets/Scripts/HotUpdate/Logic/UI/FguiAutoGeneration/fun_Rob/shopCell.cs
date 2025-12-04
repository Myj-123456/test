/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class shopCell : GComponent
    {
        public Controller isLastStatus;
        public GLoader img_shield;
        public GTextField lb_count;
        public GImage n6;
        public GButton btn_buy;
        public const string URL = "ui://z1on8kwdqqn4pkt";

        public static shopCell CreateInstance()
        {
            return (shopCell)UIPackage.CreateObject("fun_Rob", "shopCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            isLastStatus = GetControllerAt(0);
            img_shield = (GLoader)GetChildAt(0);
            lb_count = (GTextField)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            btn_buy = (GButton)GetChildAt(3);
        }
    }
}