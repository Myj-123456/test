/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class chatItemRenderer : GComponent
    {
        public Controller chatType;
        public Controller referer;
        public Controller emojie;
        public GImage n28;
        public GImage n43;
        public GImage n29;
        public GImage n45;
        public chatHead head;
        public chatHead head2;
        public GImage n32;
        public GTextField txt_lv;
        public GRichTextField lb_info2;
        public GRichTextField lb_info;
        public GRichTextField lb_userName;
        public GRichTextField lb_userName2;
        public GTextField txt_lv2;
        public GRichTextField lb_sysInfo;
        public ui_postion pos;
        public ui_postion pos2;
        public GImage n51;
        public GLoader pic;
        public GGroup n53;
        public GImage n52;
        public GLoader pic2;
        public GGroup n54;
        public GImage n36;
        public GTextField ref_lab;
        public GGroup n44;
        public GImage n46;
        public GTextField ref_lab2;
        public GGroup n48;
        public const string URL = "ui://z9jypfq8f94npgl";

        public static chatItemRenderer CreateInstance()
        {
            return (chatItemRenderer)UIPackage.CreateObject("fun_Chat", "chatItemRenderer");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            chatType = GetControllerAt(0);
            referer = GetControllerAt(1);
            emojie = GetControllerAt(2);
            n28 = (GImage)GetChildAt(0);
            n43 = (GImage)GetChildAt(1);
            n29 = (GImage)GetChildAt(2);
            n45 = (GImage)GetChildAt(3);
            head = (chatHead)GetChildAt(4);
            head2 = (chatHead)GetChildAt(5);
            n32 = (GImage)GetChildAt(6);
            txt_lv = (GTextField)GetChildAt(7);
            lb_info2 = (GRichTextField)GetChildAt(8);
            lb_info = (GRichTextField)GetChildAt(9);
            lb_userName = (GRichTextField)GetChildAt(10);
            lb_userName2 = (GRichTextField)GetChildAt(11);
            txt_lv2 = (GTextField)GetChildAt(12);
            lb_sysInfo = (GRichTextField)GetChildAt(13);
            pos = (ui_postion)GetChildAt(14);
            pos2 = (ui_postion)GetChildAt(15);
            n51 = (GImage)GetChildAt(16);
            pic = (GLoader)GetChildAt(17);
            n53 = (GGroup)GetChildAt(18);
            n52 = (GImage)GetChildAt(19);
            pic2 = (GLoader)GetChildAt(20);
            n54 = (GGroup)GetChildAt(21);
            n36 = (GImage)GetChildAt(22);
            ref_lab = (GTextField)GetChildAt(23);
            n44 = (GGroup)GetChildAt(24);
            n46 = (GImage)GetChildAt(25);
            ref_lab2 = (GTextField)GetChildAt(26);
            n48 = (GGroup)GetChildAt(27);
        }
    }
}