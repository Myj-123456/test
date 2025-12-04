/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class FlowerFairiesItem : GComponent
    {
        public GLoader img_icon;
        public const string URL = "ui://z1b78orpphdaq";

        public static FlowerFairiesItem CreateInstance()
        {
            return (FlowerFairiesItem)UIPackage.CreateObject("fun_Battle", "FlowerFairiesItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            img_icon = (GLoader)GetChildAt(0);
        }
    }
}