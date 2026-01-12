/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class plant_grid1 : GComponent
    {
        public Controller status;
        public Controller quality;
        public GLoader bg_loader;
        public GLoader image_loader;
        public GImage n26;
        public GImage n28;
        public GImage n27;
        public GTextField count_txt;
        public GTextField name_txt;
        public GTextField level_txt;
        public const string URL = "ui://dpcxz2fih3ye3u";

        public static plant_grid1 CreateInstance()
        {
            return (plant_grid1)UIPackage.CreateObject("fun_Scene", "plant_grid1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            quality = GetControllerAt(1);
            bg_loader = (GLoader)GetChildAt(0);
            image_loader = (GLoader)GetChildAt(1);
            n26 = (GImage)GetChildAt(2);
            n28 = (GImage)GetChildAt(3);
            n27 = (GImage)GetChildAt(4);
            count_txt = (GTextField)GetChildAt(5);
            name_txt = (GTextField)GetChildAt(6);
            level_txt = (GTextField)GetChildAt(7);
        }
    }
}