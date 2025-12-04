/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class btn_message : GButton
    {
        public GImage n2;
        public GImage red_point;
        public GTextField titleLab;
        public const string URL = "ui://tx86642vkg4atwpw5";

        public static btn_message CreateInstance()
        {
            return (btn_message)UIPackage.CreateObject("fun_FriendsTrade", "btn_message");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            red_point = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}