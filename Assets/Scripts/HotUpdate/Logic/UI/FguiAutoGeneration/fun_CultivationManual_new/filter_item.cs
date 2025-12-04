/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class filter_item : GComponent
    {
        public Controller status;
        public GImage n5;
        public GImage img_selected;
        public GTextField titleLab;
        public const string URL = "ui://ekoic0wriust14";

        public static filter_item CreateInstance()
        {
            return (filter_item)UIPackage.CreateObject("fun_CultivationManual_new", "filter_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n5 = (GImage)GetChildAt(0);
            img_selected = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}