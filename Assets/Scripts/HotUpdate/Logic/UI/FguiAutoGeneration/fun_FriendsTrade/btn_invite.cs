/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class btn_invite : GButton
    {
        public GImage n2;
        public GImage n1;
        public const string URL = "ui://tx86642vkg4atwpw8";

        public static btn_invite CreateInstance()
        {
            return (btn_invite)UIPackage.CreateObject("fun_FriendsTrade", "btn_invite");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
        }
    }
}