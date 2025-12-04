/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_plant
{
    public partial class btn_free_speed : GButton
    {
        public GImage n4;
        public GImage n13;
        public GTextField titleLab;
        public const string URL = "ui://4905g7p7nwd51b";

        public static btn_free_speed CreateInstance()
        {
            return (btn_free_speed)UIPackage.CreateObject("fun_plant", "btn_free_speed");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            n13 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}