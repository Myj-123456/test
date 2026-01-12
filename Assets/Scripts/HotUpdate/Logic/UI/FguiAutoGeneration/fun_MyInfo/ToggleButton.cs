/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class ToggleButton : GComponent
    {
        public Controller select;
        public GImage n22;
        public GImage n24;
        public GImage n23;
        public GImage n25;
        public GTextField txt_open;
        public GTextField txt_close;
        public const string URL = "ui://ehkqmfbps23e1yjp7t6";

        public static ToggleButton CreateInstance()
        {
            return (ToggleButton)UIPackage.CreateObject("fun_MyInfo", "ToggleButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            select = GetControllerAt(0);
            n22 = (GImage)GetChildAt(0);
            n24 = (GImage)GetChildAt(1);
            n23 = (GImage)GetChildAt(2);
            n25 = (GImage)GetChildAt(3);
            txt_open = (GTextField)GetChildAt(4);
            txt_close = (GTextField)GetChildAt(5);
        }
    }
}