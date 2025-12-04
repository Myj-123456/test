/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class name_input : GComponent
    {
        public GImage n25;
        public GLoader bg;
        public GImage n27;
        public GImage n29;
        public GImage n30;
        public GImage n26;
        public GTextField title;
        public GTextField tipLab;
        public GTextInput txt_input;
        public GButton btn_sure;
        public GButton close_btn;
        public GButton random_btn;
        public const string URL = "ui://ehkqmfbpkbhv1yjp7xg";

        public static name_input CreateInstance()
        {
            return (name_input)UIPackage.CreateObject("fun_MyInfo", "name_input");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n25 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n27 = (GImage)GetChildAt(2);
            n29 = (GImage)GetChildAt(3);
            n30 = (GImage)GetChildAt(4);
            n26 = (GImage)GetChildAt(5);
            title = (GTextField)GetChildAt(6);
            tipLab = (GTextField)GetChildAt(7);
            txt_input = (GTextInput)GetChildAt(8);
            btn_sure = (GButton)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
            random_btn = (GButton)GetChildAt(11);
        }
    }
}