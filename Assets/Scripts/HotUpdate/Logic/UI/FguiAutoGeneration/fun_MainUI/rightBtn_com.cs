/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class rightBtn_com : GComponent
    {
        public Controller status;
        public rightBtn_scroll scroll;
        public const string URL = "ui://fa0hi8ybfm3f2m";

        public static rightBtn_com CreateInstance()
        {
            return (rightBtn_com)UIPackage.CreateObject("fun_MainUI", "rightBtn_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            scroll = (rightBtn_scroll)GetChildAt(0);
        }
    }
}