/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class ui_postion : GComponent
    {
        public Controller type;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public GTextField txt_position;
        public const string URL = "ui://qfpad3q0tewh1yjp7zn";

        public static ui_postion CreateInstance()
        {
            return (ui_postion)UIPackage.CreateObject("fun_Guild_plant", "ui_postion");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            txt_position = (GTextField)GetChildAt(3);
        }
    }
}