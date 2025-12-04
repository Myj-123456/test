/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class chose_quality_item : GComponent
    {
        public Controller status;
        public GImage n5;
        public GImage n6;
        public GLoader pic;
        public GTextField titileLab;
        public const string URL = "ui://nj16dzxym3gh52";

        public static chose_quality_item CreateInstance()
        {
            return (chose_quality_item)UIPackage.CreateObject("fun_Florist", "chose_quality_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n5 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            pic = (GLoader)GetChildAt(2);
            titileLab = (GTextField)GetChildAt(3);
        }
    }
}