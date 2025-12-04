/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class btn_turn : GButton
    {
        public GImage n3;
        public const string URL = "ui://qz6135j3s62s1yjp7yv";

        public static btn_turn CreateInstance()
        {
            return (btn_turn)UIPackage.CreateObject("fun_Guild_New", "btn_turn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
        }
    }
}