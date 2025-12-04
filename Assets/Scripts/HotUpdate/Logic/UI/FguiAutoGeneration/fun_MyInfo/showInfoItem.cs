/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class showInfoItem : GComponent
    {
        public GImage n1;
        public GTextField num;
        public GTextField decLab;
        public const string URL = "ui://ehkqmfbpiust13";

        public static showInfoItem CreateInstance()
        {
            return (showInfoItem)UIPackage.CreateObject("fun_MyInfo", "showInfoItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            num = (GTextField)GetChildAt(1);
            decLab = (GTextField)GetChildAt(2);
        }
    }
}