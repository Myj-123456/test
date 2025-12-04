/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class greenPicBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public GLoader pic;
        public GTextField countLab;
        public const string URL = "ui://mjiw43v9mpj31yjp7tp";

        public static greenPicBtn CreateInstance()
        {
            return (greenPicBtn)UIPackage.CreateObject("common_New", "greenPicBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            pic = (GLoader)GetChildAt(2);
            countLab = (GTextField)GetChildAt(3);
        }
    }
}