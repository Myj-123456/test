/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Help
{
    public partial class txtCom : GComponent
    {
        public GRichTextField descTxt;
        public const string URL = "ui://64mm4k23i7zvjtwq8o";

        public static txtCom CreateInstance()
        {
            return (txtCom)UIPackage.CreateObject("fun_Help", "txtCom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            descTxt = (GRichTextField)GetChildAt(0);
        }
    }
}