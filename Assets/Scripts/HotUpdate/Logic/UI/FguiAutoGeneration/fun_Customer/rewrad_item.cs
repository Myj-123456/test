/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class rewrad_item : GButton
    {
        public Controller button;
        public Controller status;
        public GLoader bg;
        public GLoader pic;
        public GComponent ikeImg;
        public GImage n5;
        public GTextField numLab;
        public const string URL = "ui://pcr735xhcs1ml";

        public static rewrad_item CreateInstance()
        {
            return (rewrad_item)UIPackage.CreateObject("fun_Customer", "rewrad_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            status = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            ikeImg = (GComponent)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            numLab = (GTextField)GetChildAt(4);
        }
    }
}