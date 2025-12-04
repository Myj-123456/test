/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class yonghuxieyi : GComponent
    {
        public GImage n41;
        public GImage n42;
        public GLoader bg;
        public GImage n43;
        public GTextField title_txt;
        public GList list;
        public GButton close_btn;
        public const string URL = "ui://ehkqmfbps23e1yjp7t5";

        public static yonghuxieyi CreateInstance()
        {
            return (yonghuxieyi)UIPackage.CreateObject("fun_MyInfo", "yonghuxieyi");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n41 = (GImage)GetChildAt(0);
            n42 = (GImage)GetChildAt(1);
            bg = (GLoader)GetChildAt(2);
            n43 = (GImage)GetChildAt(3);
            title_txt = (GTextField)GetChildAt(4);
            list = (GList)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
        }
    }
}