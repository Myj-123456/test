/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationShop
{
    public partial class ShopItemRender : GComponent
    {
        public Controller sell;
        public GImage n41;
        public GLoader img;
        public GImage n45;
        public GButton buy_btn;
        public GButton getted;
        public GTextField name_txt;
        public GTextField count;
        public GTextField count_txt;
        public const string URL = "ui://zussolhpefh1obg";

        public static ShopItemRender CreateInstance()
        {
            return (ShopItemRender)UIPackage.CreateObject("fun_CultivationShop", "ShopItemRender");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            sell = GetControllerAt(0);
            n41 = (GImage)GetChildAt(0);
            img = (GLoader)GetChildAt(1);
            n45 = (GImage)GetChildAt(2);
            buy_btn = (GButton)GetChildAt(3);
            getted = (GButton)GetChildAt(4);
            name_txt = (GTextField)GetChildAt(5);
            count = (GTextField)GetChildAt(6);
            count_txt = (GTextField)GetChildAt(7);
        }
    }
}