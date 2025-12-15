/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_visitdetails : GButton
    {
        public Controller button;
        public GImage n2;
        public const string URL = "ui://fteyf9nzrw6k1yjp7uk";

        public static btn_visitdetails CreateInstance()
        {
            return (btn_visitdetails)UIPackage.CreateObject("fun_Friends", "btn_visitdetails");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
        }
    }
}