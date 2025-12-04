/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class task_item : GComponent
    {
        public Controller status;
        public GImage n4;
        public GImage n9;
        public GImage n11;
        public GLoader icon;
        public GLoader quality_img;
        public GImage n7;
        public GTextField titleLab;
        public GRichTextField scoreLab1;
        public head head;
        public GRichTextField scoreLab2;
        public GTextField running_txt;
        public const string URL = "ui://qefze8qitewh3";

        public static task_item CreateInstance()
        {
            return (task_item)UIPackage.CreateObject("fun_Guild_Match", "task_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
            n11 = (GImage)GetChildAt(2);
            icon = (GLoader)GetChildAt(3);
            quality_img = (GLoader)GetChildAt(4);
            n7 = (GImage)GetChildAt(5);
            titleLab = (GTextField)GetChildAt(6);
            scoreLab1 = (GRichTextField)GetChildAt(7);
            head = (head)GetChildAt(8);
            scoreLab2 = (GRichTextField)GetChildAt(9);
            running_txt = (GTextField)GetChildAt(10);
        }
    }
}