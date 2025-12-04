/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class yinsixieyi : GComponent
    {
        public GImage n41;
        public GImage n42;
        public GLoader bg;
        public GTextField title_txt;
        public GList list;
        public GButton close_btn;
        public GImage n43;
        public const string URL = "ui://ehkqmfbps23e1yjp7t4";

        public static yinsixieyi CreateInstance()
        {
            return (yinsixieyi)UIPackage.CreateObject("fun_MyInfo", "yinsixieyi");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n41 = (GImage)GetChildAt(0);
            n42 = (GImage)GetChildAt(1);
            bg = (GLoader)GetChildAt(2);
            title_txt = (GTextField)GetChildAt(3);
            list = (GList)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            n43 = (GImage)GetChildAt(6);
        }
    }
}