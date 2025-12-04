/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class more_com : GComponent
    {
        public GImage n1;
        public GButton report_btn;
        public GButton del_btn;
        public GButton back_btn;
        public const string URL = "ui://ehkqmfbpj9p61yjp7y5";

        public static more_com CreateInstance()
        {
            return (more_com)UIPackage.CreateObject("fun_MyInfo", "more_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            report_btn = (GButton)GetChildAt(1);
            del_btn = (GButton)GetChildAt(2);
            back_btn = (GButton)GetChildAt(3);
        }
    }
}