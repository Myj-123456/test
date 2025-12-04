/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class submit_btn : GButton
    {
        public GImage n1;
        public GTextField titleLab1;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9lmjv1ayr8cq";

        public static submit_btn CreateInstance()
        {
            return (submit_btn)UIPackage.CreateObject("common_New", "submit_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            titleLab1 = (GTextField)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}