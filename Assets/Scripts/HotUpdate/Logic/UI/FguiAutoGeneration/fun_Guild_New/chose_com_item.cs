/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class chose_com_item : GButton
    {
        public Controller button;
        public GImage n1;
        public GTextField titleLab;
        public const string URL = "ui://qz6135j3m3gh1yjp811";

        public static chose_com_item CreateInstance()
        {
            return (chose_com_item)UIPackage.CreateObject("fun_Guild_New", "chose_com_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}