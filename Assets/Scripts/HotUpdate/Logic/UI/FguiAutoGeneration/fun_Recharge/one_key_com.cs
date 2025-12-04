/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class one_key_com : GComponent
    {
        public GImage n1;
        public GTextField titleLab;
        public GTextField txt_1;
        public GTextField txt_2;
        public GTextField txt_3;
        public GTextField txt_4;
        public GTextField txt_5;
        public GTextField txt_6;
        public const string URL = "ui://w3ox9yltdidl1s";

        public static one_key_com CreateInstance()
        {
            return (one_key_com)UIPackage.CreateObject("fun_Recharge", "one_key_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            txt_1 = (GTextField)GetChildAt(2);
            txt_2 = (GTextField)GetChildAt(3);
            txt_3 = (GTextField)GetChildAt(4);
            txt_4 = (GTextField)GetChildAt(5);
            txt_5 = (GTextField)GetChildAt(6);
            txt_6 = (GTextField)GetChildAt(7);
        }
    }
}