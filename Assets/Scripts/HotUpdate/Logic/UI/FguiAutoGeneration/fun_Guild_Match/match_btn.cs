/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class match_btn : GButton
    {
        public Controller status;
        public GImage n1;
        public GImage n3;
        public GImage n5;
        public GImage n6;
        public GImage n7;
        public GTextField titleLab;
        public const string URL = "ui://qefze8qir0nz2a";

        public static match_btn CreateInstance()
        {
            return (match_btn)UIPackage.CreateObject("fun_Guild_Match", "match_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            n7 = (GImage)GetChildAt(4);
            titleLab = (GTextField)GetChildAt(5);
        }
    }
}