/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class findBtn : GButton
    {
        public GImage n6;
        public GImage n8;
        public const string URL = "ui://tx86642vd5gv1ayr7sr";

        public static findBtn CreateInstance()
        {
            return (findBtn)UIPackage.CreateObject("fun_FriendsTrade", "findBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            n8 = (GImage)GetChildAt(1);
        }
    }
}