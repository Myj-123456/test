/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class roleBubble : GComponent
    {
        public Controller state;
        public Controller doubleTab;
        public Controller status;
        public GImage bmp_bg;
        public GImage n10;
        public GImage n11;
        public GImage n12;
        public ikeImg img_loader;
        public GImage n7;
        public GTextField doubleLab;
        public GGroup n9;
        public const string URL = "ui://mjiw43v9q9bj1yjp7uj";

        public static roleBubble CreateInstance()
        {
            return (roleBubble)UIPackage.CreateObject("common_New", "roleBubble");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            doubleTab = GetControllerAt(1);
            status = GetControllerAt(2);
            bmp_bg = (GImage)GetChildAt(0);
            n10 = (GImage)GetChildAt(1);
            n11 = (GImage)GetChildAt(2);
            n12 = (GImage)GetChildAt(3);
            img_loader = (ikeImg)GetChildAt(4);
            n7 = (GImage)GetChildAt(5);
            doubleLab = (GTextField)GetChildAt(6);
            n9 = (GGroup)GetChildAt(7);
        }
    }
}