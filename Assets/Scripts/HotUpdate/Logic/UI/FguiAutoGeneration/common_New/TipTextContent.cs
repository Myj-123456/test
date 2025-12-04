/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class TipTextContent : GComponent
    {
        public Controller status;
        public GImage n3;
        public GRichTextField notice_txt;
        public const string URL = "ui://mjiw43v9d9bk1yjp7s3";

        public static TipTextContent CreateInstance()
        {
            return (TipTextContent)UIPackage.CreateObject("common_New", "TipTextContent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            notice_txt = (GRichTextField)GetChildAt(1);
        }
    }
}