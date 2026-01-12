/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class btn_exchange : GButton
    {
        public Controller status;
        public GImage n3;
        public GTextField titleLab;
        public GLoader pic;
        public GImage n4;
        public const string URL = "ui://97nah3khj68svx";

        public static btn_exchange CreateInstance()
        {
            return (btn_exchange)UIPackage.CreateObject("fun_Draw", "btn_exchange");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            pic = (GLoader)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
        }
    }
}