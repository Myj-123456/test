/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class seventh_sign_item : GButton
    {
        public Controller button;
        public Controller status;
        public GImage n2;
        public GImage n3;
        public GLoader icon;
        public GTextField dayLab;
        public GGraph n4;
        public const string URL = "ui://awswhm01s7sl1yjp849";

        public static seventh_sign_item CreateInstance()
        {
            return (seventh_sign_item)UIPackage.CreateObject("fun_Welfare", "seventh_sign_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            status = GetControllerAt(1);
            n2 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            icon = (GLoader)GetChildAt(2);
            dayLab = (GTextField)GetChildAt(3);
            n4 = (GGraph)GetChildAt(4);
        }
    }
}