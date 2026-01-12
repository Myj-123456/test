/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class toggleBtnOneKeyPlant1 : GComponent
    {
        public Controller select;
        public GImage n26;
        public GImage n22;
        public GImage n23;
        public GTextField n24;
        public const string URL = "ui://dpcxz2fih3ye3g";

        public static toggleBtnOneKeyPlant1 CreateInstance()
        {
            return (toggleBtnOneKeyPlant1)UIPackage.CreateObject("fun_Scene", "toggleBtnOneKeyPlant1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            select = GetControllerAt(0);
            n26 = (GImage)GetChildAt(0);
            n22 = (GImage)GetChildAt(1);
            n23 = (GImage)GetChildAt(2);
            n24 = (GTextField)GetChildAt(3);
        }
    }
}