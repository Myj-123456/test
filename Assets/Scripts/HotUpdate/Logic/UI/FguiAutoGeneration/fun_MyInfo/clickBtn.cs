/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class clickBtn : GButton
    {
        public Controller type;
        public GImage n6;
        public GImage n8;
        public GTextField titleLab;
        public const string URL = "ui://ehkqmfbpj9p61yjp83o";

        public static clickBtn CreateInstance()
        {
            return (clickBtn)UIPackage.CreateObject("fun_MyInfo", "clickBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n6 = (GImage)GetChildAt(0);
            n8 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}