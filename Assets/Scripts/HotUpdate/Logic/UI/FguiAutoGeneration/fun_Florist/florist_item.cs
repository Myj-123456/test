/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class florist_item : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GLoader pic;
        public GImage n6;
        public GImage n3;
        public GTextField nameLab;
        public const string URL = "ui://nj16dzxym3ghd";

        public static florist_item CreateInstance()
        {
            return (florist_item)UIPackage.CreateObject("fun_Florist", "florist_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
            nameLab = (GTextField)GetChildAt(4);
        }
    }
}