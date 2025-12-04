/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class foldBtn : GButton
    {
        public GImage n4;
        public const string URL = "ui://6bdpq80knwgi1yjp7qv";

        public static foldBtn CreateInstance()
        {
            return (foldBtn)UIPackage.CreateObject("common", "foldBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
        }
    }
}