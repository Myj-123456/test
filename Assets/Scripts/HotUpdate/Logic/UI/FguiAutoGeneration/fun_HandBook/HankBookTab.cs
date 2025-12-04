/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_HandBook
{
    public partial class HankBookTab : GButton
    {
        public Controller button;
        public GImage n1;
        public GImage n2;
        public GLoader pic;
        public GTextField titleLab1;
        public GTextField titleLab2;
        public const string URL = "ui://puwwarlikqhx4";

        public static HankBookTab CreateInstance()
        {
            return (HankBookTab)UIPackage.CreateObject("fun_HandBook", "HankBookTab");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            pic = (GLoader)GetChildAt(2);
            titleLab1 = (GTextField)GetChildAt(3);
            titleLab2 = (GTextField)GetChildAt(4);
        }
    }
}