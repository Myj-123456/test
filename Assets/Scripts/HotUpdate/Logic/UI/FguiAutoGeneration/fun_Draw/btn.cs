/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class btn : GButton
    {
        public Controller type;
        public GImage n1;
        public GImage n5;
        public GImage n4;
        public GTextField titleLab;
        public const string URL = "ui://97nah3khbwsw7";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_Draw", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}