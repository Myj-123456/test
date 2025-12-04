/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class notice_txt : GComponent
    {
        public GTextField txt_notice;
        public const string URL = "ui://qz6135j3j8rp1ayr89o";

        public static notice_txt CreateInstance()
        {
            return (notice_txt)UIPackage.CreateObject("fun_Guild_New", "notice_txt");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            txt_notice = (GTextField)GetChildAt(0);
        }
    }
}