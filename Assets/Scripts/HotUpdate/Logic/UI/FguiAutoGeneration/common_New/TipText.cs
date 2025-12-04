/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class TipText : GComponent
    {
        public TipTextContent content;
        public const string URL = "ui://mjiw43v9d9bk1yjp7s2";

        public static TipText CreateInstance()
        {
            return (TipText)UIPackage.CreateObject("common_New", "TipText");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            content = (TipTextContent)GetChildAt(0);
        }
    }
}