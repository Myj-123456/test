/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class planting_ope_item : GButton
    {
        public Controller quality;
        public Controller chose;
        public Controller button;
        public GLoader bg_loader;
        public GImage n12;
        public GImage n13;
        public GImage n14;
        public GImage n16;
        public GImage n15;
        public GImage n17;
        public GImage n18;
        public GLoader image_loader;
        public GImage n22;
        public GTextField name_txt;
        public GLoader style_img;
        public GImage n21;
        public const string URL = "ui://qfpad3q0tewh2k";

        public static planting_ope_item CreateInstance()
        {
            return (planting_ope_item)UIPackage.CreateObject("fun_Guild_plant", "planting_ope_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            quality = GetControllerAt(0);
            chose = GetControllerAt(1);
            button = GetControllerAt(2);
            bg_loader = (GLoader)GetChildAt(0);
            n12 = (GImage)GetChildAt(1);
            n13 = (GImage)GetChildAt(2);
            n14 = (GImage)GetChildAt(3);
            n16 = (GImage)GetChildAt(4);
            n15 = (GImage)GetChildAt(5);
            n17 = (GImage)GetChildAt(6);
            n18 = (GImage)GetChildAt(7);
            image_loader = (GLoader)GetChildAt(8);
            n22 = (GImage)GetChildAt(9);
            name_txt = (GTextField)GetChildAt(10);
            style_img = (GLoader)GetChildAt(11);
            n21 = (GImage)GetChildAt(12);
        }
    }
}