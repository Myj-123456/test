/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class clickBtn7 : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9j9p61yjp83l";

        public static clickBtn7 CreateInstance()
        {
            return (clickBtn7)UIPackage.CreateObject("common_New", "clickBtn7");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}