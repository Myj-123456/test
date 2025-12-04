/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class clickBtn2 : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9i64u1yjp7t5";

        public static clickBtn2 CreateInstance()
        {
            return (clickBtn2)UIPackage.CreateObject("common_New", "clickBtn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}