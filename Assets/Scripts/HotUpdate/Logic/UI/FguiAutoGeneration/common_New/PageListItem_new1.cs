/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class PageListItem_new1 : GComponent
    {
        public Controller status;
        public GLoader n5;
        public GImage n6;
        public const string URL = "ui://mjiw43v9iust1yjp7ss";

        public static PageListItem_new1 CreateInstance()
        {
            return (PageListItem_new1)UIPackage.CreateObject("common_New", "PageListItem_new1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n5 = (GLoader)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
        }
    }
}