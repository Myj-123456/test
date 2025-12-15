/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class ShopItemRender : GComponent
    {
        public Controller sell;
        public GImage n51;
        public GComponent reward;
        public greenPicBtn buy_btn;
        public GTextField name_txt;
        public GTextField limitLab;
        public GImage n53;
        public GTextField selllab;
        public GGroup n55;
        public const string URL = "ui://wm7arakybwsw1ayr7s5";

        public static ShopItemRender CreateInstance()
        {
            return (ShopItemRender)UIPackage.CreateObject("fun_VipShop", "ShopItemRender");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            sell = GetControllerAt(0);
            n51 = (GImage)GetChildAt(0);
            reward = (GComponent)GetChildAt(1);
            buy_btn = (greenPicBtn)GetChildAt(2);
            name_txt = (GTextField)GetChildAt(3);
            limitLab = (GTextField)GetChildAt(4);
            n53 = (GImage)GetChildAt(5);
            selllab = (GTextField)GetChildAt(6);
            n55 = (GGroup)GetChildAt(7);
        }
    }
}