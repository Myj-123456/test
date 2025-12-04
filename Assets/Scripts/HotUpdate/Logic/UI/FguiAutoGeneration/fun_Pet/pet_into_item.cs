/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class pet_into_item : GButton
    {
        public Controller button;
        public GImage n1;
        public GLoader icon;
        public GLoader icon1;
        public const string URL = "ui://o7kmyysdx92m2r";

        public static pet_into_item CreateInstance()
        {
            return (pet_into_item)UIPackage.CreateObject("fun_Pet", "pet_into_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            icon1 = (GLoader)GetChildAt(2);
        }
    }
}