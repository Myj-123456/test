/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class btn2 : GButton
    {
        public GImage n11;
        public const string URL = "ui://ehkqmfbpu0i31yjp7sz";

        public static btn2 CreateInstance()
        {
            return (btn2)UIPackage.CreateObject("fun_MyInfo", "btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n11 = (GImage)GetChildAt(0);
        }
    }
}