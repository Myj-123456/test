/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class chose_quality_item : GButton
    {
        public Controller button;
        public GImage n2;
        public GLoader quality_img;
        public GTextField titileLab;
        public const string URL = "ui://qefze8qir0nz2p";

        public static chose_quality_item CreateInstance()
        {
            return (chose_quality_item)UIPackage.CreateObject("fun_Guild_Match", "chose_quality_item");
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