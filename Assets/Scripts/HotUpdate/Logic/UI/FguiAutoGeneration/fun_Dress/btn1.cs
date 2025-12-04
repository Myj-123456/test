/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class btn1 : GButton
    {
        public Controller type;
        public GImage n86;
        public GImage n91;
        public GImage n92;
        public GImage n93;
        public const string URL = "ui://argzn455v5lj1yjp81l";

        public static btn1 CreateInstance()
        {
            return (btn1)UIPackage.CreateObject("fun_Dress", "btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n86 = (GImage)GetChildAt(0);
            n91 = (GImage)GetChildAt(1);
            n92 = (GImage)GetChildAt(2);
            n93 = (GImage)GetChildAt(3);
        }
    }
}