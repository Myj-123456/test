/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class best_fun : GButton
    {
        public Controller tips;
        public GImage n3;
        public GTextField titleLab;
        public GImage n5;
        public GImage n4;
        public GImage n7;
        public GImage n6;
        public const string URL = "ui://fteyf9nzg3sj1yjp7tt";

        public static best_fun CreateInstance()
        {
            return (best_fun)UIPackage.CreateObject("fun_Friends", "best_fun");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tips = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n7 = (GImage)GetChildAt(4);
            n6 = (GImage)GetChildAt(5);
        }
    }
}