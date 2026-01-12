/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class my_task_view : GComponent
    {
        public GLoader bg;
        public GTextField txt_Title;
        public GImage n7;
        public GList list;
        public GButton close_btn;
        public const string URL = "ui://qefze8qitewh6";

        public static my_task_view CreateInstance()
        {
            return (my_task_view)UIPackage.CreateObject("fun_Guild_Match", "my_task_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            txt_Title = (GTextField)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            list = (GList)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
        }
    }
}