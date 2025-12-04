/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class shop_main_view : GComponent
    {
        public Controller tab;
        public ShopView cultivation_view;
        public OtherView other_view;
        public VipShop vip_shop;
        public GButton close_btn;
        public page_btn seed_btn;
        public page_btn other_btn;
        public page_btn vip_btn;
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
            cultivation_view = (ShopView)GetChildAt(0);
            other_view = (OtherView)GetChildAt(1);
            vip_shop = (VipShop)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            seed_btn = (page_btn)GetChildAt(4);
            other_btn = (page_btn)GetChildAt(5);
            vip_btn = (page_btn)GetChildAt(6);
            n8 = (GGroup)GetChildAt(7);
        }
    }
}