/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class btn1 : GButton
    {
        public GImage n1;
        public GImage n2;
        public GTextField titleLab;
        public const string URL = "ui://oo5kr0yot5nh1o";

        public static btn1 CreateInstance()
        {
            return (btn1)UIPackage.CreateObject("fun_Tour_Land", "btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}