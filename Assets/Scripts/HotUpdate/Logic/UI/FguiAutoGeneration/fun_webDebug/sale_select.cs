/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_webDebug
{
    public partial class sale_select : GButton
    {
        public Controller button;
        public Controller state;
        public GImage n2;
        public GImage n0;
        public GImage img_complate;
        public const string URL = "ui://658koyrilmjvju";

        public static sale_select CreateInstance()
        {
            return (sale_select)UIPackage.CreateObject("fun_webDebug", "sale_select");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            state = GetControllerAt(1);
            n2 = (GImage)GetChildAt(0);
            n0 = (GImage)GetChildAt(1);
            img_complate = (GImage)GetChildAt(2);
        }
    }
}