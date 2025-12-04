/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class ShopItemRender : GComponent
    {
        public Controller sell;
        public GImage n47;
        public GLoader bg;
        public GLoader img;
        public GButton buy_btn;
        public GTextField name_txt;
        public GTextField limitLab;
        public GTextField countLab;
        public const string URL = "ui://wm7arakybwsw1ayr7s5";

        public static ShopItemRender CreateInstance()
        {
            return (ShopItemRender)UIPackage.CreateObject("fun_VipShop", "ShopItemRender");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            sell = GetControllerAt(0);
            n47 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            img = (GLoader)GetChildAt(2);
            buy_btn = (GButton)GetChildAt(3);
            name_txt = (GTextField)GetChildAt(4);
            limitLab = (GTextField)GetChildAt(5);
            countLab = (GTextField)GetChildAt(6);
        }
    }
}