/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class plant_grid : GComponent
    {
        public Controller status;
        public Controller quality;
        public GLoader bg_loader;
        public GImage n12;
        public GImage n13;
        public GImage n14;
        public GImage n16;
        public GImage n15;
        public GImage n17;
        public GImage n18;
        public GLoader image_loader;
        public GTextField count_txt;
        public GTextField name_txt;
        public const string URL = "ui://6wv667gujpt93";

        public static plant_grid CreateInstance()
        {
            return (plant_grid)UIPackage.CreateObject("fun_Guild", "plant_grid");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            quality = GetControllerAt(1);
            bg_loader = (GLoader)GetChildAt(0);
            n12 = (GImage)GetChildAt(1);
            n13 = (GImage)GetChildAt(2);
            n14 = (GImage)GetChildAt(3);
            n16 = (GImage)GetChildAt(4);
            n15 = (GImage)GetChildAt(5);
            n17 = (GImage)GetChildAt(6);
            n18 = (GImage)GetChildAt(7);
            image_loader = (GLoader)GetChildAt(8);
            count_txt = (GTextField)GetChildAt(9);
            name_txt = (GTextField)GetChildAt(10);
        }
    }
}