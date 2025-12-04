/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class chatItemRenderer1 : GComponent
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
        public GImage n51;
        public GLoader pic;
        public GGroup n52;
        public GImage n53;
        public GLoader pic2;
        public GGroup n54;
        public GImage n36;
        public GTextField ref_lab;
        public GGroup n44;
        public GImage n46;
        public GTextField ref_lab2;
        public GGroup n48;
        public const string URL = "ui://z9jypfq811rnu1yjp7xj";

        public static chatItemRenderer1 CreateInstance()
        {
            return (chatItemRenderer1)UIPackage.CreateObject("fun_Chat", "chatItemRenderer1");
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
            n51 = (GImage)GetChildAt(14);
            pic = (GLoader)GetChildAt(15);
            n52 = (GGroup)GetChildAt(16);
            n53 = (GImage)GetChildAt(17);
            pic2 = (GLoader)GetChildAt(18);
            n54 = (GGroup)GetChildAt(19);
            n36 = (GImage)GetChildAt(20);
            ref_lab = (GTextField)GetChildAt(21);
            n44 = (GGroup)GetChildAt(22);
            n46 = (GImage)GetChildAt(23);
            ref_lab2 = (GTextField)GetChildAt(24);
            n48 = (GGroup)GetChildAt(25);
        }
    }
}