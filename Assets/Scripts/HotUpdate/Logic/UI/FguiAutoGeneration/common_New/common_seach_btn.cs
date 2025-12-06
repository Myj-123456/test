/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_seach_btn : GButton
    {
        public GImage n0;
        public const string URL = "ui://mjiw43v9kelj1yjp859";

        public static common_seach_btn CreateInstance()
        {
            return (common_seach_btn)UIPackage.CreateObject("common_New", "common_seach_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
        }
    }
}