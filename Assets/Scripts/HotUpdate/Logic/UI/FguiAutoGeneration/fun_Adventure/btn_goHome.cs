/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Adventure
{
    public partial class btn_goHome : GButton
    {
        public GImage n0;
        public const string URL = "ui://3yqg0b4edpr1n";

        public static btn_goHome CreateInstance()
        {
            return (btn_goHome)UIPackage.CreateObject("fun_Adventure", "btn_goHome");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
        }
    }
}