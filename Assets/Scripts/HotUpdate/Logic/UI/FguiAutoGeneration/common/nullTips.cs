/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class nullTips : GComponent
    {
        public GImage n2;
        public GTextField emptyText;
        public const string URL = "ui://6bdpq80knwgi1yjp7ra";

        public static nullTips CreateInstance()
        {
            return (nullTips)UIPackage.CreateObject("common", "nullTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            emptyText = (GTextField)GetChildAt(1);
        }
    }
}