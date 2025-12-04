/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_shop_item : GButton
    {
        public Controller button;
        public Controller unlock;
        public GLoader bg;
        public GLoader icon;
        public GLoader cost_img;
        public GImage n6;
        public GImage n13;
        public GTextField unlockLab;
        public GTextField haveLab;
        public GTextField cost_num;
        public GGraph buy_btn;
        public const string URL = "ui://argzn455hstt1yjp843";

        public static dress_shop_item CreateInstance()
        {
            return (dress_shop_item)UIPackage.CreateObject("fun_Dress", "dress_shop_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            unlock = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            cost_img = (GLoader)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            n13 = (GImage)GetChildAt(4);
            unlockLab = (GTextField)GetChildAt(5);
            haveLab = (GTextField)GetChildAt(6);
            cost_num = (GTextField)GetChildAt(7);
            buy_btn = (GGraph)GetChildAt(8);
        }
    }
}