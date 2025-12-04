/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class interActTipView : GComponent
    {
        public GLoader image;
        public GTextField emptyText;
        public const string URL = "ui://6bdpq80knwgi1yjp7qn";

        public static interActTipView CreateInstance()
        {
            return (interActTipView)UIPackage.CreateObject("common", "interActTipView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            image = (GLoader)GetChildAt(0);
            emptyText = (GTextField)GetChildAt(1);
        }
    }
}