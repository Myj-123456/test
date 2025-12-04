/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerShop
{
    public partial class FurnitureItem : GComponent
    {
        public GLoader img_quality;
        public GLoader img_icon;
        public GImage txt_use;
        public const string URL = "ui://4nb2f1z8shfj3";

        public static FurnitureItem CreateInstance()
        {
            return (FurnitureItem)UIPackage.CreateObject("fun_FlowerShop", "FurnitureItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            img_quality = (GLoader)GetChildAt(0);
            img_icon = (GLoader)GetChildAt(1);
            txt_use = (GImage)GetChildAt(2);
        }
    }
}