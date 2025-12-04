/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class privacyBtn : GComponent
    {
        public GTextField tiaoluan_txt;
        public GImage n22;
        public const string URL = "ui://ehkqmfbps23e1yjp7t1";

        public static privacyBtn CreateInstance()
        {
            return (privacyBtn)UIPackage.CreateObject("fun_MyInfo", "privacyBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tiaoluan_txt = (GTextField)GetChildAt(0);
            n22 = (GImage)GetChildAt(1);
        }
    }
}