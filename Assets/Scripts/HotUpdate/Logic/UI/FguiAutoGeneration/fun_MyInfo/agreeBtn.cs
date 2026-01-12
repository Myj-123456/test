/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class agreeBtn : GComponent
    {
        public GTextField xieyi_txt;
        public GImage n24;
        public const string URL = "ui://ehkqmfbprb3e1yjp846";

        public static agreeBtn CreateInstance()
        {
            return (agreeBtn)UIPackage.CreateObject("fun_MyInfo", "agreeBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            xieyi_txt = (GTextField)GetChildAt(0);
            n24 = (GImage)GetChildAt(1);
        }
    }
}