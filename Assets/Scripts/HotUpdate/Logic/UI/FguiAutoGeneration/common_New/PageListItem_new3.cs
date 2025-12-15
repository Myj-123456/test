/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class PageListItem_new3 : GComponent
    {
        public Controller status;
        public GImage n11;
        public GImage n10;
        public const string URL = "ui://mjiw43v9dhbs1yjp85y";

        public static PageListItem_new3 CreateInstance()
        {
            return (PageListItem_new3)UIPackage.CreateObject("common_New", "PageListItem_new3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n11 = (GImage)GetChildAt(0);
            n10 = (GImage)GetChildAt(1);
        }
    }
}