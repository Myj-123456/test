/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class limit_item : GComponent
    {
        public Controller status;
        public GImage n10;
        public GImage n12;
        public GImage n11;
        public GImage n13;
        public GLoader bg;
        public GLoader pic;
        public GTextField numLab;
        public GTextField nameLab;
        public GTextField limitLab;
        public const string URL = "ui://nj16dzxym3gh5";

        public static limit_item CreateInstance()
        {
            return (limit_item)UIPackage.CreateObject("fun_Florist", "limit_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n10 = (GImage)GetChildAt(0);
            n12 = (GImage)GetChildAt(1);
            n11 = (GImage)GetChildAt(2);
            n13 = (GImage)GetChildAt(3);
            bg = (GLoader)GetChildAt(4);
            pic = (GLoader)GetChildAt(5);
            numLab = (GTextField)GetChildAt(6);
            nameLab = (GTextField)GetChildAt(7);
            limitLab = (GTextField)GetChildAt(8);
        }
    }
}