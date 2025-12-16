/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_lock : GButton
    {
        public GImage n8;
        public GTextField n10;
        public const string URL = "ui://fteyf9nzcl9t1yjp7v4";

        public static btn_lock CreateInstance()
        {
            return (btn_lock)UIPackage.CreateObject("fun_Friends", "btn_lock");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n8 = (GImage)GetChildAt(0);
            n10 = (GTextField)GetChildAt(1);
        }
    }
}