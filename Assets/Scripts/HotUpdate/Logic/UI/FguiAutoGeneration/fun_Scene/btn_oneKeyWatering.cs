/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class btn_oneKeyWatering : GButton
    {
        public Controller state;
        public GGraph bg;
        public GImage n14;
        public GImage n15;
        public GTextField titleLab;
        public GImage n17;
        public const string URL = "ui://dpcxz2fiw2582j";

        public static btn_oneKeyWatering CreateInstance()
        {
            return (btn_oneKeyWatering)UIPackage.CreateObject("fun_Scene", "btn_oneKeyWatering");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            bg = (GGraph)GetChildAt(0);
            n14 = (GImage)GetChildAt(1);
            n15 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            n17 = (GImage)GetChildAt(4);
        }
    }
}