/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class txtListItem : GComponent
    {
        public GRichTextField lb_content;
        public const string URL = "ui://ehkqmfbps23e1yjp7t2";

        public static txtListItem CreateInstance()
        {
            return (txtListItem)UIPackage.CreateObject("fun_MyInfo", "txtListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            lb_content = (GRichTextField)GetChildAt(0);
        }
    }
}