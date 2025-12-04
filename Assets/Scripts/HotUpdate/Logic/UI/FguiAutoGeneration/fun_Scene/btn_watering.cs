/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class btn_watering : GButton
    {
        public Controller state;
        public GGraph bg;
        public GImage n14;
        public GTextField titleLab;
        public GLoader image_loader;
        public const string URL = "ui://dpcxz2fiw2582h";

        public static btn_watering CreateInstance()
        {
            return (btn_watering)UIPackage.CreateObject("fun_Scene", "btn_watering");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            bg = (GGraph)GetChildAt(0);
            n14 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            image_loader = (GLoader)GetChildAt(3);
        }
    }
}