/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class my_rank_item : GComponent
    {
        public Controller status;
        public GImage n1;
        public GImage n15;
        public GImage n16;
        public GImage n17;
        public GImage n9;
        public GImage n11;
        public GImage n10;
        public GImage n12;
        public head head;
        public GImage n5;
        public GTextField levelLab;
        public GTextField rankLab;
        public GTextField nameLab;
        public GTextField powerLab;
        public GTextField taskLab;
        public GTextField scoreLab;
        public const string URL = "ui://qefze8qir0nz3c";

        public static my_rank_item CreateInstance()
        {
            return (my_rank_item)UIPackage.CreateObject("fun_Guild_Match", "my_rank_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            n16 = (GImage)GetChildAt(2);
            n17 = (GImage)GetChildAt(3);
            n9 = (GImage)GetChildAt(4);
            n11 = (GImage)GetChildAt(5);
            n10 = (GImage)GetChildAt(6);
            n12 = (GImage)GetChildAt(7);
            head = (head)GetChildAt(8);
            n5 = (GImage)GetChildAt(9);
            levelLab = (GTextField)GetChildAt(10);
            rankLab = (GTextField)GetChildAt(11);
            nameLab = (GTextField)GetChildAt(12);
            powerLab = (GTextField)GetChildAt(13);
            taskLab = (GTextField)GetChildAt(14);
            scoreLab = (GTextField)GetChildAt(15);
        }
    }
}