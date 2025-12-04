/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class toggleBtnOneKeyPlant : GComponent
    {
        public Controller select;
        public GImage n21;
        public GImage n22;
        public GImage n23;
        public GTextField n24;
        public const string URL = "ui://dpcxz2fiqgju1x";

        public static toggleBtnOneKeyPlant CreateInstance()
        {
            return (toggleBtnOneKeyPlant)UIPackage.CreateObject("fun_Scene", "toggleBtnOneKeyPlant");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            select = GetControllerAt(0);
            n21 = (GImage)GetChildAt(0);
            n22 = (GImage)GetChildAt(1);
            n23 = (GImage)GetChildAt(2);
            n24 = (GTextField)GetChildAt(3);
        }
    }
}