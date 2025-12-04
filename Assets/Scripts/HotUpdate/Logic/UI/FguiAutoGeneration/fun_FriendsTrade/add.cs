/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class add : GButton
    {
        public Controller c1;
        public GImage n7;
        public GImage n8;
        public const string URL = "ui://tx86642vudko1ayr7rr";

        public static add CreateInstance()
        {
            return (add)UIPackage.CreateObject("fun_FriendsTrade", "add");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            n7 = (GImage)GetChildAt(0);
            n8 = (GImage)GetChildAt(1);
        }
    }
}