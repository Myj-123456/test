/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class btn_pre_show : GButton
    {
        public GImage n8;
        public GImage n13;
        public GTextField titleLab;
        public const string URL = "ui://qfpad3q0tewh1yjp7zx";

        public static btn_pre_show CreateInstance()
        {
            return (btn_pre_show)UIPackage.CreateObject("fun_Guild_plant", "btn_pre_show");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n8 = (GImage)GetChildAt(0);
            n13 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}