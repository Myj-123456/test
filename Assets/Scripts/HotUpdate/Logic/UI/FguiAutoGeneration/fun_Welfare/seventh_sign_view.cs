/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class seventh_sign_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GList list;
        public GButton getBtn;
        public seventh_sign_item item1;
        public seventh_sign_item item2;
        public seventh_sign_item item3;
        public seventh_sign_item item4;
        public seventh_sign_item item5;
        public seventh_sign_item item6;
        public seventh_sign_item item7;
        public GGroup n10;
        public const string URL = "ui://awswhm01s7sl1yjp848";

        public static seventh_sign_view CreateInstance()
        {
            return (seventh_sign_view)UIPackage.CreateObject("fun_Welfare", "seventh_sign_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            list = (GList)GetChildAt(1);
            getBtn = (GButton)GetChildAt(2);
            item1 = (seventh_sign_item)GetChildAt(3);
            item2 = (seventh_sign_item)GetChildAt(4);
            item3 = (seventh_sign_item)GetChildAt(5);
            item4 = (seventh_sign_item)GetChildAt(6);
            item5 = (seventh_sign_item)GetChildAt(7);
            item6 = (seventh_sign_item)GetChildAt(8);
            item7 = (seventh_sign_item)GetChildAt(9);
            n10 = (GGroup)GetChildAt(10);
        }
    }
}