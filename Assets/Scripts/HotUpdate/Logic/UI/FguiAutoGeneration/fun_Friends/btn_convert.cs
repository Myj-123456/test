/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_convert : GButton
    {
        public Controller button;
        public GImage n2;
        public const string URL = "ui://fteyf9nzoanl1yjp7un";

        public static btn_convert CreateInstance()
        {
            return (btn_convert)UIPackage.CreateObject("fun_Friends", "btn_convert");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
        }
    }
}