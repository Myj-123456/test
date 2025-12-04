/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class FurnitureEditUI : GComponent
    {
        public GImage n0;
        public GButton btn_close;
        public GButton btn_confirm;
        public const string URL = "ui://dpcxz2fihau8a";

        public static FurnitureEditUI CreateInstance()
        {
            return (FurnitureEditUI)UIPackage.CreateObject("fun_Scene", "FurnitureEditUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            btn_close = (GButton)GetChildAt(1);
            btn_confirm = (GButton)GetChildAt(2);
        }
    }
}