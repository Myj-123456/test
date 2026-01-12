/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class match_history_item : GComponent
    {
        public Controller status;
        public GImage n1;
        public GImage n9;
        public GImage n10;
        public GImage n11;
        public GImage n12;
        public GImage n13;
        public GImage n14;
        public GTextField titileLab;
        public GTextField frist_txt;
        public GTextField sed_txt;
        public GTextField three_txt;
        public GTextField fristLab;
        public GTextField sedLab;
        public GTextField threeLab;
        public const string URL = "ui://qefze8qir0nz35";

        public static match_history_item CreateInstance()
        {
            return (match_history_item)UIPackage.CreateObject("fun_Guild_Match", "match_history_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
            n10 = (GImage)GetChildAt(2);
            n11 = (GImage)GetChildAt(3);
            n12 = (GImage)GetChildAt(4);
            n13 = (GImage)GetChildAt(5);
            n14 = (GImage)GetChildAt(6);
            titileLab = (GTextField)GetChildAt(7);
            frist_txt = (GTextField)GetChildAt(8);
            sed_txt = (GTextField)GetChildAt(9);
            three_txt = (GTextField)GetChildAt(10);
            fristLab = (GTextField)GetChildAt(11);
            sedLab = (GTextField)GetChildAt(12);
            threeLab = (GTextField)GetChildAt(13);
        }
    }
}