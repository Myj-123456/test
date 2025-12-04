/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Help
{
    public partial class help : GComponent
    {
        public GImage n96;
        public GLoader bg;
        public GTextField title;
        public GButton close_btn;
        public txtCom txtCom;
        public const string URL = "ui://64mm4k23a12jp0y";

        public static help CreateInstance()
        {
            return (help)UIPackage.CreateObject("fun_Help", "help");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n96 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            title = (GTextField)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            txtCom = (txtCom)GetChildAt(4);
        }
    }
}