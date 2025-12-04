/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class btn_level : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://6wv667gui68d1ayr88d";

        public static btn_level CreateInstance()
        {
            return (btn_level)UIPackage.CreateObject("fun_Guild", "btn_level");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}