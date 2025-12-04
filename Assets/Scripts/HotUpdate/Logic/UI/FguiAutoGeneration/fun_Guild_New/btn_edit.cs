/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class btn_edit : GButton
    {
        public GImage n3;
        public const string URL = "ui://qz6135j3l2dk1yjp7xx";

        public static btn_edit CreateInstance()
        {
            return (btn_edit)UIPackage.CreateObject("fun_Guild_New", "btn_edit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
        }
    }
}