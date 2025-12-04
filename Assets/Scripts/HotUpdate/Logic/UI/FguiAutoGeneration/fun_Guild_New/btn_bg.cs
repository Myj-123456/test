/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class btn_bg : GButton
    {
        public Controller button;
        public GLoader icon;
        public const string URL = "ui://qz6135j3s62s1yjp7yq";

        public static btn_bg CreateInstance()
        {
            return (btn_bg)UIPackage.CreateObject("fun_Guild_New", "btn_bg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            icon = (GLoader)GetChildAt(0);
        }
    }
}