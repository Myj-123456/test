/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class my_rank_view : GComponent
    {
        public GList list;
        public GImage n2;
        public GImage n7;
        public GImage n8;
        public GImage n9;
        public GImage n10;
        public GImage n13;
        public GTextField rankLab;
        public head head;
        public GTextField nameLab;
        public GTextField powerLab;
        public GTextField taskLab;
        public GTextField scoreLab;
        public GTextField levelLab;
        public const string URL = "ui://qefze8qir0nz3b";

        public static my_rank_view CreateInstance()
        {
            return (my_rank_view)UIPackage.CreateObject("fun_Guild_Match", "my_rank_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list = (GList)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            n8 = (GImage)GetChildAt(3);
            n9 = (GImage)GetChildAt(4);
            n10 = (GImage)GetChildAt(5);
            n13 = (GImage)GetChildAt(6);
            rankLab = (GTextField)GetChildAt(7);
            head = (head)GetChildAt(8);
            nameLab = (GTextField)GetChildAt(9);
            powerLab = (GTextField)GetChildAt(10);
            taskLab = (GTextField)GetChildAt(11);
            scoreLab = (GTextField)GetChildAt(12);
            levelLab = (GTextField)GetChildAt(13);
        }
    }
}