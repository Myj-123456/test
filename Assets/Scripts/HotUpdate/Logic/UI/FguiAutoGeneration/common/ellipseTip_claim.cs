/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class ellipseTip_claim : GComponent
    {
        public GImage n21;
        public GTextField txt;
        public const string URL = "ui://6bdpq80knwgi1yjp7r5";

        public static ellipseTip_claim CreateInstance()
        {
            return (ellipseTip_claim)UIPackage.CreateObject("common", "ellipseTip_claim");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n21 = (GImage)GetChildAt(0);
            txt = (GTextField)GetChildAt(1);
        }
    }
}