/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_introduce : GButton
    {
        public Controller button;
        public GImage n0;
        public GTextField n1;
        public const string URL = "ui://fteyf9nzoanl1yjp7um";

        public static btn_introduce CreateInstance()
        {
            return (btn_introduce)UIPackage.CreateObject("fun_Friends", "btn_introduce");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GTextField)GetChildAt(1);
        }
    }
}