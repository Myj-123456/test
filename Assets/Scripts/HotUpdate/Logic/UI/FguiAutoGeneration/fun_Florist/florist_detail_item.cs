/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class florist_detail_item : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GRichTextField numLab;
        public GTextField nameLab;
        public const string URL = "ui://nj16dzxym3gh1";

        public static florist_detail_item CreateInstance()
        {
            return (florist_detail_item)UIPackage.CreateObject("fun_Florist", "florist_detail_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            numLab = (GRichTextField)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
        }
    }
}