/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class yellowPicBtn : GButton
    {
        public GImage n6;
        public GLoader pic;
        public GTextField countLab;
        public GGroup n11;
        public GTextField titleLab;
        public GGroup n10;
        public const string URL = "ui://mjiw43v9q9bj1yjp7u2";

        public static yellowPicBtn CreateInstance()
        {
            return (yellowPicBtn)UIPackage.CreateObject("common_New", "yellowPicBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            countLab = (GTextField)GetChildAt(2);
            n11 = (GGroup)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
            n10 = (GGroup)GetChildAt(5);
        }
    }
}