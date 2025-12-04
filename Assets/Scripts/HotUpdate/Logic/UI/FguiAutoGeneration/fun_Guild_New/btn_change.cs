/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class btn_change : GButton
    {
        public GImage n3;
        public const string URL = "ui://qz6135j3s62s1yjp7yr";

        public static btn_change CreateInstance()
        {
            return (btn_change)UIPackage.CreateObject("fun_Guild_New", "btn_change");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
        }
    }
}