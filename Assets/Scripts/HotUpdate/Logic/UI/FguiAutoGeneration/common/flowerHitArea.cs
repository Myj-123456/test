/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class flowerHitArea : GComponent
    {
        public GImage n48;
        public const string URL = "ui://6bdpq80knwgi1yjp7rc";

        public static flowerHitArea CreateInstance()
        {
            return (flowerHitArea)UIPackage.CreateObject("common", "flowerHitArea");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n48 = (GImage)GetChildAt(0);
        }
    }
}