/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Notice
{
    public partial class GameNoticeListItem : GComponent
    {
        public GRichTextField lb_content;
        public const string URL = "ui://6ijclyxxs4tzvgk2od";

        public static GameNoticeListItem CreateInstance()
        {
            return (GameNoticeListItem)UIPackage.CreateObject("fun_Notice", "GameNoticeListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            lb_content = (GRichTextField)GetChildAt(0);
        }
    }
}