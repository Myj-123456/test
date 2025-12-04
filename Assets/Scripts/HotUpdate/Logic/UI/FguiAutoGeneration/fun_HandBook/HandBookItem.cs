/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_HandBook
{
    public partial class HandBookItem : GComponent
    {
        public Controller status;
        public GImage n6;
        public GImage n16;
        public GImage n7;
        public GLoader pic;
        public GRichTextField decLab;
        public GTextField lvLab;
        public GButton gotoBtn;
        public const string URL = "ui://puwwarlikqhx9";

        public static HandBookItem CreateInstance()
        {
            return (HandBookItem)UIPackage.CreateObject("fun_HandBook", "HandBookItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n6 = (GImage)GetChildAt(0);
            n16 = (GImage)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            pic = (GLoader)GetChildAt(3);
            decLab = (GRichTextField)GetChildAt(4);
            lvLab = (GTextField)GetChildAt(5);
            gotoBtn = (GButton)GetChildAt(6);
        }
    }
}