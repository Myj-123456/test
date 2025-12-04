/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class chose_qualirt : GComponent
    {
        public GImage n1;
        public GImage n9;
        public chose_item have_btn;
        public chose_item no_btn;
        public chose_quality_item quality_btn1;
        public chose_quality_item quality_btn2;
        public chose_quality_item quality_btn3;
        public chose_quality_item quality_btn5;
        public const string URL = "ui://nj16dzxym3gh53";

        public static chose_qualirt CreateInstance()
        {
            return (chose_qualirt)UIPackage.CreateObject("fun_Florist", "chose_qualirt");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
            have_btn = (chose_item)GetChildAt(2);
            no_btn = (chose_item)GetChildAt(3);
            quality_btn1 = (chose_quality_item)GetChildAt(4);
            quality_btn2 = (chose_quality_item)GetChildAt(5);
            quality_btn3 = (chose_quality_item)GetChildAt(6);
            quality_btn5 = (chose_quality_item)GetChildAt(7);
        }
    }
}