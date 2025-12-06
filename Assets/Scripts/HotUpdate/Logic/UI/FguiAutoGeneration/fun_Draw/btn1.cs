/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class btn1 : GButton
    {
        public Controller type;
        public GImage n1;
        public GImage n8;
        public GImage n7;
        public GTextField titleLab;
        public const string URL = "ui://97nah3khu25nus";

        public static btn1 CreateInstance()
        {
            return (btn1)UIPackage.CreateObject("fun_Draw", "btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n8 = (GImage)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}