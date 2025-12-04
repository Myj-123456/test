/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class florist_book_item : GComponent
    {
        public Controller limit;
        public Controller quality;
        public GLoader bg;
        public GLoader quality_img;
        public GLoader rare_img;
        public GImage n10;
        public GTextField nameLab;
        public GTextField collectLab;
        public GTextField limitLab;
        public const string URL = "ui://nj16dzxym3gh9";

        public static florist_book_item CreateInstance()
        {
            return (florist_book_item)UIPackage.CreateObject("fun_Florist", "florist_book_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            limit = GetControllerAt(0);
            quality = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            quality_img = (GLoader)GetChildAt(1);
            rare_img = (GLoader)GetChildAt(2);
            n10 = (GImage)GetChildAt(3);
            nameLab = (GTextField)GetChildAt(4);
            collectLab = (GTextField)GetChildAt(5);
            limitLab = (GTextField)GetChildAt(6);
        }
    }
}