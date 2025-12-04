/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn : GButton
    {
        public Controller type;
        public GImage n11;
        public GImage n8;
        public GImage n9;
        public GImage n12;
        public GTextField titleLab;
        public const string URL = "ui://fteyf9nzi64u1yjp7t9";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_Friends", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n11 = (GImage)GetChildAt(0);
            n8 = (GImage)GetChildAt(1);
            n9 = (GImage)GetChildAt(2);
            n12 = (GImage)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
        }
    }
}