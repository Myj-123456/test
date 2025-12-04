/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace fun_Notice
{
    public class fun_NoticeBinder
    {
        public static void BindAll()
        {
            UIObjectFactory.SetPackageItemExtension(GameNotice.URL, typeof(GameNotice));
            UIObjectFactory.SetPackageItemExtension(UpdateContent.URL, typeof(UpdateContent));
            UIObjectFactory.SetPackageItemExtension(CloseBtn.URL, typeof(CloseBtn));
            UIObjectFactory.SetPackageItemExtension(GameNoticeListItem.URL, typeof(GameNoticeListItem));
        }
    }
}