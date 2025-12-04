/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class btn1 : GButton
    {
        public Controller type;
        public GImage n6;
        public GTextField titleLab;
        public GImage n8;
        public GImage n9;
        public GImage n10;
        public const string URL = "ui://ehkqmfbpiust1yjp7sw";

        public static btn1 CreateInstance()
        {
            return (btn1)UIPackage.CreateObject("fun_MyInfo", "btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n8 = (GImage)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
            n10 = (GImage)GetChildAt(4);
        }
    }
}