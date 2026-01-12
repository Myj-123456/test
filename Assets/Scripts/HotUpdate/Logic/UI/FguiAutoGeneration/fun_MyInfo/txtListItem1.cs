/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class txtListItem1 : GComponent
    {
        public GRichTextField lb_content;
        public const string URL = "ui://ehkqmfbprb3e1yjp842";

        public static txtListItem1 CreateInstance()
        {
            return (txtListItem1)UIPackage.CreateObject("fun_MyInfo", "txtListItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            lb_content = (GRichTextField)GetChildAt(0);
        }
    }
}