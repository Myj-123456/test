/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class chose_btn : GComponent
    {
        public Controller select;
        public Controller show;
        public GImage n0;
        public GImage n4;
        public GTextField titleLab;
        public const string URL = "ui://qz6135j3m3gh1yjp80x";

        public static chose_btn CreateInstance()
        {
            return (chose_btn)UIPackage.CreateObject("fun_Guild_New", "chose_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            select = GetControllerAt(0);
            show = GetControllerAt(1);
            n0 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}