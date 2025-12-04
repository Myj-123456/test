/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class rewrad_item1 : GButton
    {
        public Controller button;
        public Controller status;
        public GLoader bg;
        public GLoader pic;
        public GTextField numLab;
        public const string URL = "ui://pcr735xhcs1m1h";

        public static rewrad_item1 CreateInstance()
        {
            return (rewrad_item1)UIPackage.CreateObject("fun_Customer", "rewrad_item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            status = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
        }
    }
}