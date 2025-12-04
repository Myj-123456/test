/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class PageListItem_new2 : GComponent
    {
        public Controller status;
        public GImage n8;
        public GImage n7;
        public const string URL = "ui://mjiw43v9q9bj1yjp7ud";

        public static PageListItem_new2 CreateInstance()
        {
            return (PageListItem_new2)UIPackage.CreateObject("common_New", "PageListItem_new2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n8 = (GImage)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
        }
    }
}