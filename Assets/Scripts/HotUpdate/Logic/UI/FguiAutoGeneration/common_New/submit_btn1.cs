/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class submit_btn1 : GButton
    {
        public GImage n1;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9d9bk1yjp7tj";

        public static submit_btn1 CreateInstance()
        {
            return (submit_btn1)UIPackage.CreateObject("common_New", "submit_btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}