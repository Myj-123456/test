/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class BuffItem : GComponent
    {
        public GLoader img_icon;
        public const string URL = "ui://z1b78orpphdan";

        public static BuffItem CreateInstance()
        {
            return (BuffItem)UIPackage.CreateObject("fun_Battle", "BuffItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            img_icon = (GLoader)GetChildAt(0);
        }
    }
}