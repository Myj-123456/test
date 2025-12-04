/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_SellingFlowers
{
    public partial class PageListItem_new : GComponent
    {
        public Controller status;
        public GImage n8;
        public GImage n9;
        public const string URL = "ui://ztwqlwa2q9bj1yjp7uu";

        public static PageListItem_new CreateInstance()
        {
            return (PageListItem_new)UIPackage.CreateObject("fun_SellingFlowers", "PageListItem_new");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n8 = (GImage)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
        }
    }
}