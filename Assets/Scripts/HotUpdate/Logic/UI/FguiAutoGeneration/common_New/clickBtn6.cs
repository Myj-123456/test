/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class clickBtn6 : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9j9p61yjp83k";

        public static clickBtn6 CreateInstance()
        {
            return (clickBtn6)UIPackage.CreateObject("common_New", "clickBtn6");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}