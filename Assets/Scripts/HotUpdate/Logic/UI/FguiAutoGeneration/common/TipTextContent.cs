/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class TipTextContent : GComponent
    {
        public Controller status;
        public GImage bg;
        public GImage n2;
        public GRichTextField notice_txt;
        public const string URL = "ui://6bdpq80knd7j1yjp7rr";

        public static TipTextContent CreateInstance()
        {
            return (TipTextContent)UIPackage.CreateObject("common", "TipTextContent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            notice_txt = (GRichTextField)GetChildAt(2);
        }
    }
}