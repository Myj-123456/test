/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class title_item : GButton
    {
        public Controller button;
        public Controller unlock;
        public Controller type;
        public GImage n2;
        public GLoader icon;
        public GTextField nameLab;
        public GTextField timeLab;
        public GImage n8;
        public GImage n10;
        public GImage n6;
        public GImage n11;
        public const string URL = "ui://ehkqmfbpj9p61yjp7yj";

        public static title_item CreateInstance()
        {
            return (title_item)UIPackage.CreateObject("fun_MyInfo", "title_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            unlock = GetControllerAt(1);
            type = GetControllerAt(2);
            n2 = (GImage)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            nameLab = (GTextField)GetChildAt(2);
            timeLab = (GTextField)GetChildAt(3);
            n8 = (GImage)GetChildAt(4);
            n10 = (GImage)GetChildAt(5);
            n6 = (GImage)GetChildAt(6);
            n11 = (GImage)GetChildAt(7);
        }
    }
}