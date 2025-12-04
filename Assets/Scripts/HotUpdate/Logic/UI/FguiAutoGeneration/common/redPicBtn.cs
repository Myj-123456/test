/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class redPicBtn : GButton
    {
        public GImage n6;
        public GLoader pic;
        public GTextField titleLab;
        public const string URL = "ui://6bdpq80knwgi1yjp7r4";

        public static redPicBtn CreateInstance()
        {
            return (redPicBtn)UIPackage.CreateObject("common", "redPicBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}