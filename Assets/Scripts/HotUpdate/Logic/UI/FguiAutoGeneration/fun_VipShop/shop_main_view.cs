/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class shop_main_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public ShopView cultivation_view;
        public OtherView other_view;
        public VipShop vip_shop;
        public GImage n11;
        public GButton close_btn;
        public GButton seed_btn;
        public GButton other_btn;
        public GButton vip_btn;
        public GGroup n8;
        public const string URL = "ui://wm7arakybwswh";

        public static shop_main_view CreateInstance()
        {
            return (shop_main_view)UIPackage.CreateObject("fun_VipShop", "shop_main_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            cultivation_view = (ShopView)GetChildAt(1);
            other_view = (OtherView)GetChildAt(2);
            vip_shop = (VipShop)GetChildAt(3);
            n11 = (GImage)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            seed_btn = (GButton)GetChildAt(6);
            other_btn = (GButton)GetChildAt(7);
            vip_btn = (GButton)GetChildAt(8);
            n8 = (GGroup)GetChildAt(9);
        }
    }
}