/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class btn : GButton
    {
        public Controller type;
        public GImage n3;
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://jugv3wv4q9bjk";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_FriendsTrade_New", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
        }
    }
}