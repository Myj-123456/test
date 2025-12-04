/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class back_btn : GButton
    {
        public GImage n1;
        public const string URL = "ui://6bdpq80knwgi1yjp7re";

        public static back_btn CreateInstance()
        {
            return (back_btn)UIPackage.CreateObject("common", "back_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
        }
    }
}