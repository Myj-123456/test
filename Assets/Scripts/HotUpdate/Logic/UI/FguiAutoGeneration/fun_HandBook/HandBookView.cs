/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_HandBook
{
    public partial class HandBookView : GComponent
    {
        public GImage n3;
        public GImage n4;
        public GButton close_btn;
        public GButton question_btn;
        public GList tabList;
        public GList list;
        public GTextField titleLab;
        public const string URL = "ui://puwwarlikqhx0";

        public static HandBookView CreateInstance()
        {
            return (HandBookView)UIPackage.CreateObject("fun_HandBook", "HandBookView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            close_btn = (GButton)GetChildAt(2);
            question_btn = (GButton)GetChildAt(3);
            tabList = (GList)GetChildAt(4);
            list = (GList)GetChildAt(5);
            titleLab = (GTextField)GetChildAt(6);
        }
    }
}