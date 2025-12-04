/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class flower_god_item : GButton
    {
        public Controller button;
        public GImage n1;
        public GImage n3;
        public GLoader pic;
        public const string URL = "ui://oo5kr0yot5nh15";

        public static flower_god_item CreateInstance()
        {
            return (flower_god_item)UIPackage.CreateObject("fun_Tour_Land", "flower_god_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            pic = (GLoader)GetChildAt(2);
        }
    }
}