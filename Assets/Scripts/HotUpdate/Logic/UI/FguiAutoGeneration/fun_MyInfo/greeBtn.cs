/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class greeBtn : GComponent
    {
        public GTextField xieyi_txt;
        public GImage n23;
        public const string URL = "ui://ehkqmfbps23e1yjp7t0";

        public static greeBtn CreateInstance()
        {
            return (greeBtn)UIPackage.CreateObject("fun_MyInfo", "greeBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            xieyi_txt = (GTextField)GetChildAt(0);
            n23 = (GImage)GetChildAt(1);
        }
    }
}