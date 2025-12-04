/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class ToggleButton_1 : GComponent
    {
        public Controller select;
        public GImage n21;
        public GImage n22;
        public GImage n23;
        public GTextField n24;
        public const string URL = "ui://z1on8kwdja6i1ayr8l0";

        public static ToggleButton_1 CreateInstance()
        {
            return (ToggleButton_1)UIPackage.CreateObject("fun_Rob", "ToggleButton_1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            select = GetControllerAt(0);
            n21 = (GImage)GetChildAt(0);
            n22 = (GImage)GetChildAt(1);
            n23 = (GImage)GetChildAt(2);
            n24 = (GTextField)GetChildAt(3);
        }
    }
}