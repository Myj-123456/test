/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class btn : GButton
    {
        public Controller type;
        public GImage n1;
        public GTextField titleLab;
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public const string URL = "ui://44kfvb3rx92m2u";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_FlowerGold", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            n6 = (GImage)GetChildAt(4);
        }
    }
}