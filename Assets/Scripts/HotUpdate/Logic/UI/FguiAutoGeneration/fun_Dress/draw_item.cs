/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class draw_item : GButton
    {
        public Controller button;
        public GImage n2;
        public GImage n0;
        public GTextField nameLab;
        public GTextField numLab;
        public const string URL = "ui://argzn455m3gh1n";

        public static draw_item CreateInstance()
        {
            return (draw_item)UIPackage.CreateObject("fun_Dress", "draw_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            n0 = (GImage)GetChildAt(1);
            nameLab = (GTextField)GetChildAt(2);
            numLab = (GTextField)GetChildAt(3);
        }
    }
}