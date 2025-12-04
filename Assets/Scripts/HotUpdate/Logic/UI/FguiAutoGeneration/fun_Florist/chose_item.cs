/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class chose_item : GComponent
    {
        public Controller status;
        public GImage n5;
        public GImage n6;
        public GTextField titileLab;
        public const string URL = "ui://nj16dzxym3ghk";

        public static chose_item CreateInstance()
        {
            return (chose_item)UIPackage.CreateObject("fun_Florist", "chose_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n5 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            titileLab = (GTextField)GetChildAt(2);
        }
    }
}