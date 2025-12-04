/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class btn_set_pass : GButton
    {
        public GImage n5;
        public GImage n4;
        public const string URL = "ui://6wv667guo7qr1ayr88q";

        public static btn_set_pass CreateInstance()
        {
            return (btn_set_pass)UIPackage.CreateObject("fun_Guild", "btn_set_pass");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
        }
    }
}