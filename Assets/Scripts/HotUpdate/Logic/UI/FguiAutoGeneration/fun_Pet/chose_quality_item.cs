/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class chose_quality_item : GButton
    {
        public Controller button;
        public GImage n2;
        public GLoader quality_img;
        public GTextField titileLab;
        public const string URL = "ui://o7kmyysdx92m1yjp80l";

        public static chose_quality_item CreateInstance()
        {
            return (chose_quality_item)UIPackage.CreateObject("fun_Pet", "chose_quality_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            quality_img = (GLoader)GetChildAt(1);
            titileLab = (GTextField)GetChildAt(2);
        }
    }
}