/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class btn_search : GButton
    {
        public GImage n3;
        public GImage n4;
        public GTextField titleLab;
        public const string URL = "ui://6wv667guijtf1ayr88i";

        public static btn_search CreateInstance()
        {
            return (btn_search)UIPackage.CreateObject("fun_Guild", "btn_search");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}