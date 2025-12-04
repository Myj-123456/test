/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class btn_gift : GButton
    {
        public GImage n0;
        public GImage n3;
        public GImage n1;
        public GImage n2;
        public const string URL = "ui://qz6135j3s62s1yjp7yt";

        public static btn_gift CreateInstance()
        {
            return (btn_gift)UIPackage.CreateObject("fun_Guild_New", "btn_gift");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            n1 = (GImage)GetChildAt(2);
            n2 = (GImage)GetChildAt(3);
        }
    }
}