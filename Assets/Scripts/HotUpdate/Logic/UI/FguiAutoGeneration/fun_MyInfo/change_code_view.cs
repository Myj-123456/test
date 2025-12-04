/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class change_code_view : GComponent
    {
        public GImage n25;
        public GLoader bg;
        public GImage n34;
        public GImage n27;
        public GImage n29;
        public GImage n30;
        public GTextField title;
        public GTextField tipLab;
        public GTextInput txt_input;
        public GButton btn_sure;
        public GButton close_btn;
        public GButton cancle_btn;
        public const string URL = "ui://ehkqmfbpj9p61yjp7y8";

        public static change_code_view CreateInstance()
        {
            return (change_code_view)UIPackage.CreateObject("fun_MyInfo", "change_code_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n25 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n34 = (GImage)GetChildAt(2);
            n27 = (GImage)GetChildAt(3);
            n29 = (GImage)GetChildAt(4);
            n30 = (GImage)GetChildAt(5);
            title = (GTextField)GetChildAt(6);
            tipLab = (GTextField)GetChildAt(7);
            txt_input = (GTextInput)GetChildAt(8);
            btn_sure = (GButton)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
            cancle_btn = (GButton)GetChildAt(11);
        }
    }
}