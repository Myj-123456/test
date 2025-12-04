/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class page_btn : GButton
    {
        public Controller button;
        public GImage n1;
        public GImage n2;
        public GTextField titleLab;
        public GImage red_point;
        public const string URL = "ui://44kfvb3rm3gh3r";

        public static page_btn CreateInstance()
        {
            return (page_btn)UIPackage.CreateObject("fun_FlowerGold", "page_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            red_point = (GImage)GetChildAt(3);
        }
    }
}