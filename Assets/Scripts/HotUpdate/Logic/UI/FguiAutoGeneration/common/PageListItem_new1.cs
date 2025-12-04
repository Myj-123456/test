/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class PageListItem_new1 : GComponent
    {
        public Controller status;
        public GImage n5;
        public GImage n6;
        public const string URL = "ui://6bdpq80knd7j1yjp7rq";

        public static PageListItem_new1 CreateInstance()
        {
            return (PageListItem_new1)UIPackage.CreateObject("common", "PageListItem_new1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n5 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
        }
    }
}