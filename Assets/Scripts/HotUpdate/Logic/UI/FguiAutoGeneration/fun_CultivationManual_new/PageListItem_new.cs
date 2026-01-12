/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class PageListItem_new : GComponent
    {
        public Controller status;
        public GLoader n5;
        public GImage n7;
        public const string URL = "ui://ekoic0wri9891yjp86k";

        public static PageListItem_new CreateInstance()
        {
            return (PageListItem_new)UIPackage.CreateObject("fun_CultivationManual_new", "PageListItem_new");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n5 = (GLoader)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
        }
    }
}