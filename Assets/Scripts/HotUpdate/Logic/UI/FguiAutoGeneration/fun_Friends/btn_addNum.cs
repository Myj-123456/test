/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_addNum : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://fteyf9nzrw6k1yjp7un";

        public static btn_addNum CreateInstance()
        {
            return (btn_addNum)UIPackage.CreateObject("fun_Friends", "btn_addNum");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}