/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Help
{
    public partial class disablePrompt : GComponent
    {
        public GTextField title;
        public GRichTextField descTxt;
        public const string URL = "ui://64mm4k23onryp5r";

        public static disablePrompt CreateInstance()
        {
            return (disablePrompt)UIPackage.CreateObject("fun_Help", "disablePrompt");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title = (GTextField)GetChildAt(0);
            descTxt = (GRichTextField)GetChildAt(1);
        }
    }
}