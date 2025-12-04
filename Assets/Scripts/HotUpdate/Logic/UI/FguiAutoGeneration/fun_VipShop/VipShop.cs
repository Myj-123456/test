/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class VipShop : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GLoader bg1;
        public GImage n55;
        public GImage n56;
        public GImage n57;
        public GImage n58;
        public GImage n59;
        public GImage n60;
        public GGroup n61;
        public GImage n28;
        public GList list;
        public GImage n21;
        public GTextField titleLab;
        public GButton n23;
        public GImage n24;
        public GLoader pic;
        public GTextField txt_gold;
        public GGroup n27;
        public GImage n30;
        public btn left_btn;
        public btn right_btn;
        public GLoader3D spine;
        public GImage n36;
        public GImage n49;
        public GImage n40;
        public GImage n41;
        public GImage n43;
        public GImage n44;
        public btn1 seach_btn;
        public greenPicBtn buy_btn;
        public GTextField timeLab;
        public GTextField pageLab;
        public GTextField tipLab;
        public GTextField tipLab1;
        public GTextField goldlab;
        public GTextField cashlab;
        public GTextField limitLab;
        public GTextInput inputLab;
        public GGroup n52;
        public const string URL = "ui://wm7arakyqheb0";

        public static VipShop CreateInstance()
        {
            return (VipShop)UIPackage.CreateObject("fun_VipShop", "VipShop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            n55 = (GImage)GetChildAt(2);
            n56 = (GImage)GetChildAt(3);
            n57 = (GImage)GetChildAt(4);
            n58 = (GImage)GetChildAt(5);
            n59 = (GImage)GetChildAt(6);
            n60 = (GImage)GetChildAt(7);
            n61 = (GGroup)GetChildAt(8);
            n28 = (GImage)GetChildAt(9);
            list = (GList)GetChildAt(10);
            n21 = (GImage)GetChildAt(11);
            titleLab = (GTextField)GetChildAt(12);
            n23 = (GButton)GetChildAt(13);
            n24 = (GImage)GetChildAt(14);
            pic = (GLoader)GetChildAt(15);
            txt_gold = (GTextField)GetChildAt(16);
            n27 = (GGroup)GetChildAt(17);
            n30 = (GImage)GetChildAt(18);
            left_btn = (btn)GetChildAt(19);
            right_btn = (btn)GetChildAt(20);
            spine = (GLoader3D)GetChildAt(21);
            n36 = (GImage)GetChildAt(22);
            n49 = (GImage)GetChildAt(23);
            n40 = (GImage)GetChildAt(24);
            n41 = (GImage)GetChildAt(25);
            n43 = (GImage)GetChildAt(26);
            n44 = (GImage)GetChildAt(27);
            seach_btn = (btn1)GetChildAt(28);
            buy_btn = (greenPicBtn)GetChildAt(29);
            timeLab = (GTextField)GetChildAt(30);
            pageLab = (GTextField)GetChildAt(31);
            tipLab = (GTextField)GetChildAt(32);
            tipLab1 = (GTextField)GetChildAt(33);
            goldlab = (GTextField)GetChildAt(34);
            cashlab = (GTextField)GetChildAt(35);
            limitLab = (GTextField)GetChildAt(36);
            inputLab = (GTextInput)GetChildAt(37);
            n52 = (GGroup)GetChildAt(38);
        }
    }
}