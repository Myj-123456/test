/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class role_list_view : GComponent
    {
        public GGraph rect;
        public GLoader bg;
        public GImage n5;
        public pro pro;
        public GTextField proLab;
        public GTextField proTitle;
        public GTextField expLab;
        public GList list;
        public GTextField tipLab;
        public GGroup n10;
        public const string URL = "ui://pcr735xhcs1mn";

        public static role_list_view CreateInstance()
        {
            return (role_list_view)UIPackage.CreateObject("fun_Customer", "role_list_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            rect = (GGraph)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            pro = (pro)GetChildAt(3);
            proLab = (GTextField)GetChildAt(4);
            proTitle = (GTextField)GetChildAt(5);
            expLab = (GTextField)GetChildAt(6);
            list = (GList)GetChildAt(7);
            tipLab = (GTextField)GetChildAt(8);
            n10 = (GGroup)GetChildAt(9);
        }
    }
}