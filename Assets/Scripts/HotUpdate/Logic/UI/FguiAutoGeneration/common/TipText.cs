/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class TipText : GComponent
    {
        public TipTextContent content;
        public const string URL = "ui://6bdpq80knd7j1yjp7ru";

        public static TipText CreateInstance()
        {
            return (TipText)UIPackage.CreateObject("common", "TipText");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            content = (TipTextContent)GetChildAt(0);
        }
    }
}