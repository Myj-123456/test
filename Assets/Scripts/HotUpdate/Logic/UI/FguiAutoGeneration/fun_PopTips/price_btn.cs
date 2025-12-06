/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopTips
{
    public partial class price_btn : GButton
    {
        public Controller status;
        public GImage n8;
        public GTextField titleLab;
        public GTextField titleLab1;
        public GImage n10;
        public const string URL = "ui://vhcdvi5tu25nk";

        public static price_btn CreateInstance()
        {
            return (price_btn)UIPackage.CreateObject("fun_PopTips", "price_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n8 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            titleLab1 = (GTextField)GetChildAt(2);
            n10 = (GImage)GetChildAt(3);
        }
    }
}