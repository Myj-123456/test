/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class btn_add : GButton
    {
        public GImage n3;
        public const string URL = "ui://6wv667gui68d1ayr81b";

        public static btn_add CreateInstance()
        {
            return (btn_add)UIPackage.CreateObject("fun_Guild", "btn_add");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
        }
    }
}