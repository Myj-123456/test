/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class marquee_com : GComponent
    {
        public GImage n1;
        public GTextField decLab;
        public const string URL = "ui://mjiw43v9s7sl1yjp840";

        public static marquee_com CreateInstance()
        {
            return (marquee_com)UIPackage.CreateObject("common_New", "marquee_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            decLab = (GTextField)GetChildAt(1);
        }
    }
}