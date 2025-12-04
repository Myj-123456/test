/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class greenPicBtn1 : GButton
    {
        public GImage n6;
        public GLoader pic;
        public GTextField titleLab;
        public GGroup n8;
        public const string URL = "ui://mjiw43v9mpj31yjp7tq";

        public static greenPicBtn1 CreateInstance()
        {
            return (greenPicBtn1)UIPackage.CreateObject("common_New", "greenPicBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            n8 = (GGroup)GetChildAt(3);
        }
    }
}