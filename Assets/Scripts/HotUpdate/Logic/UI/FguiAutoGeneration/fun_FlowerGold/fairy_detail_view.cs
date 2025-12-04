/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class fairy_detail_view : GComponent
    {
        public Controller have;
        public GLoader bg;
        public GLoader bg1;
        public GImage n4;
        public GImage n8;
        public GImage n17;
        public GImage n20;
        public GLoader rare_img;
        public GButton close_btn;
        public GLoader icon;
        public GTextField nameLab;
        public GTextField natureLab;
        public GTextField skillLab;
        public GTextField skillDec;
        public GTextField haveLab;
        public GList list;
        public const string URL = "ui://44kfvb3rm3gh1yjp815";

        public static fairy_detail_view CreateInstance()
        {
            return (fairy_detail_view)UIPackage.CreateObject("fun_FlowerGold", "fairy_detail_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            have = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n8 = (GImage)GetChildAt(3);
            n17 = (GImage)GetChildAt(4);
            n20 = (GImage)GetChildAt(5);
            rare_img = (GLoader)GetChildAt(6);
            close_btn = (GButton)GetChildAt(7);
            icon = (GLoader)GetChildAt(8);
            nameLab = (GTextField)GetChildAt(9);
            natureLab = (GTextField)GetChildAt(10);
            skillLab = (GTextField)GetChildAt(11);
            skillDec = (GTextField)GetChildAt(12);
            haveLab = (GTextField)GetChildAt(13);
            list = (GList)GetChildAt(14);
        }
    }
}