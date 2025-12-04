/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShareView : GComponent
    {
        public Controller status;
        public Controller power;
        public GImage n56;
        public GButton close_btn;
        public GButton btn_share;
        public GButton btn_addCount;
        public GList list;
        public GImage image;
        public GTextField lb_tip_none;
        public GRichTextField lb_tip;
        public GRichTextField lb_shareCount;
        public GTextField titleLab;
        public const string URL = "ui://zuzhxc13s3bkpnn";

        public static flowerShareView CreateInstance()
        {
            return (flowerShareView)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShareView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            power = GetControllerAt(1);
            n56 = (GImage)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            btn_share = (GButton)GetChildAt(2);
            btn_addCount = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
            image = (GImage)GetChildAt(5);
            lb_tip_none = (GTextField)GetChildAt(6);
            lb_tip = (GRichTextField)GetChildAt(7);
            lb_shareCount = (GRichTextField)GetChildAt(8);
            titleLab = (GTextField)GetChildAt(9);
        }
    }
}