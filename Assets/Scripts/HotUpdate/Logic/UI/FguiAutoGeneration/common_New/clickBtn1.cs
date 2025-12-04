/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class clickBtn1 : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9i64u1yjp7sz";

        public static clickBtn1 CreateInstance()
        {
            return (clickBtn1)UIPackage.CreateObject("common_New", "clickBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}