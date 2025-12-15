/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class VipShop : GComponent
    {
        public Controller tab;
        public GImage n86;
        public GImage n63;
        public GImage n64;
        public GLoader pic;
        public GTextField titleLab;
        public GTextField txt_gold;
        public GButton help_btn;
        public GGroup n69;
        public GList list;
        public GImage n72;
        public GImage n70;
        public GImage n71;
        public GImage n74;
        public GImage n75;
        public GImage n76;
        public GLoader3D spine;
        public GImage n77;
        public btn left_btn;
        public btn right_btn;
        public GImage n43;
        public GImage n44;
        public btn1 seach_btn;
        public GButton buy_btn;
        public GTextField timeLab;
        public GTextField preLab;
        public GTextField pageLab;
        public GTextField tipLab;
        public GTextField goldlab;
        public GTextField cashlab;
        public GTextField limitLab;
        public GTextField nameLab;
        public GTextInput inputLab;
        public GGroup n79;
        public GImage n82;
        public GImage n83;
        public GGroup n84;
        public const string URL = "ui://wm7arakyqheb0";

        public static VipShop CreateInstance()
        {
            return (VipShop)UIPackage.CreateObject("fun_VipShop", "VipShop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            n86 = (GImage)GetChildAt(0);
            n63 = (GImage)GetChildAt(1);
            n64 = (GImage)GetChildAt(2);
            pic = (GLoader)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
            txt_gold = (GTextField)GetChildAt(5);
            help_btn = (GButton)GetChildAt(6);
            n69 = (GGroup)GetChildAt(7);
            list = (GList)GetChildAt(8);
            n72 = (GImage)GetChildAt(9);
            n70 = (GImage)GetChildAt(10);
            n71 = (GImage)GetChildAt(11);
            n74 = (GImage)GetChildAt(12);
            n75 = (GImage)GetChildAt(13);
            n76 = (GImage)GetChildAt(14);
            spine = (GLoader3D)GetChildAt(15);
            n77 = (GImage)GetChildAt(16);
            left_btn = (btn)GetChildAt(17);
            right_btn = (btn)GetChildAt(18);
            n43 = (GImage)GetChildAt(19);
            n44 = (GImage)GetChildAt(20);
            seach_btn = (btn1)GetChildAt(21);
            buy_btn = (GButton)GetChildAt(22);
            timeLab = (GTextField)GetChildAt(23);
            preLab = (GTextField)GetChildAt(24);
            pageLab = (GTextField)GetChildAt(25);
            tipLab = (GTextField)GetChildAt(26);
            goldlab = (GTextField)GetChildAt(27);
            cashlab = (GTextField)GetChildAt(28);
            limitLab = (GTextField)GetChildAt(29);
            nameLab = (GTextField)GetChildAt(30);
            inputLab = (GTextInput)GetChildAt(31);
            n79 = (GGroup)GetChildAt(32);
            n82 = (GImage)GetChildAt(33);
            n83 = (GImage)GetChildAt(34);
            n84 = (GGroup)GetChildAt(35);
        }
    }
}