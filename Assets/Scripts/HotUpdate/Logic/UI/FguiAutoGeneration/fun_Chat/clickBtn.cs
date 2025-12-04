/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class clickBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://z9jypfq811rnu1yjp83e";

        public static clickBtn CreateInstance()
        {
            return (clickBtn)UIPackage.CreateObject("fun_Chat", "clickBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}