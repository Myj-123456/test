/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class nullTip : GComponent
    {
        public GImage n3;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9i64u1yjp7t6";

        public static nullTip CreateInstance()
        {
            return (nullTip)UIPackage.CreateObject("common_New", "nullTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}