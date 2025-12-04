/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class clickVideoBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public GImage n7;
        public const string URL = "ui://mjiw43v9kkb11yjp83u";

        public static clickVideoBtn CreateInstance()
        {
            return (clickVideoBtn)UIPackage.CreateObject("common_New", "clickVideoBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
        }
    }
}