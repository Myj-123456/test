/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class leftBtn_com : GComponent
    {
        public Controller status;
        public leftBtn_scroll scroll;
        public const string URL = "ui://fa0hi8ybfm3f1v";

        public static leftBtn_com CreateInstance()
        {
            return (leftBtn_com)UIPackage.CreateObject("fun_MainUI", "leftBtn_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            scroll = (leftBtn_scroll)GetChildAt(0);
        }
    }
}