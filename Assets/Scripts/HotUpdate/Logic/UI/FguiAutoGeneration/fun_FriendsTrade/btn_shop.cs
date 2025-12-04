/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class btn_shop : GButton
    {
        public GImage n2;
        public GTextField titleLab;
        public const string URL = "ui://tx86642vd4kttwpwo";

        public static btn_shop CreateInstance()
        {
            return (btn_shop)UIPackage.CreateObject("fun_FriendsTrade", "btn_shop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}