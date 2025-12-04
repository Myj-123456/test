/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class pageBtn2 : GButton
    {
        public Controller button;
        public GImage n14;
        public GImage n15;
        public GTextField titleLab;
        public const string URL = "ui://argzn455hstt1yjp82w";

        public static pageBtn2 CreateInstance()
        {
            return (pageBtn2)UIPackage.CreateObject("fun_Dress", "pageBtn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n14 = (GImage)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}