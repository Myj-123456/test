/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopGift
{
    public partial class btn : GButton
    {
        public Controller button;
        public GImage n1;
        public GImage n2;
        public GImage n6;
        public GLoader icon;
        public GImage n3;
        public GTextField timeLab;
        public GTextField timeLab1;
        public const string URL = "ui://ah12m40ag0s05";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_PopGift", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            icon = (GLoader)GetChildAt(3);
            n3 = (GImage)GetChildAt(4);
            timeLab = (GTextField)GetChildAt(5);
            timeLab1 = (GTextField)GetChildAt(6);
        }
    }
}