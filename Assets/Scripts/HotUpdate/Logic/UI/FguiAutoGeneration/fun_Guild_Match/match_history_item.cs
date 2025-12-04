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
            titileLab = (GTextField)GetChildAt(4);
            frist_txt = (GTextField)GetChildAt(5);
            sed_txt = (GTextField)GetChildAt(6);
            three_txt = (GTextField)GetChildAt(7);
            fristLab = (GTextField)GetChildAt(8);
            sedLab = (GTextField)GetChildAt(9);
            threeLab = (GTextField)GetChildAt(10);
        }
    }
}