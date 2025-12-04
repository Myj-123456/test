/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Notice
{
    public partial class CloseBtn : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://6ijclyxxqheb1yjp7v5";

        public static CloseBtn CreateInstance()
        {
            return (CloseBtn)UIPackage.CreateObject("fun_Notice", "CloseBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}