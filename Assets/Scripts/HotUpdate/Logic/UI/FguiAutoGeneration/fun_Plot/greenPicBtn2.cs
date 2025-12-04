/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class greenPicBtn2 : GButton
    {
        public GImage n6;
        public GLoader pic;
        public GTextField titleLab;
        public GImage red_point;
        public const string URL = "ui://vucpfjl8accs1yjp83d";

        public static greenPicBtn2 CreateInstance()
        {
            return (greenPicBtn2)UIPackage.CreateObject("fun_Plot", "greenPicBtn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            red_point = (GImage)GetChildAt(3);
        }
    }
}