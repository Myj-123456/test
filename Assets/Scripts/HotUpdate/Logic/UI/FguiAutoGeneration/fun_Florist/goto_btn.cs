/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class goto_btn : GButton
    {
        public GImage n1;
        public GImage n2;
        public GTextField titleLab;
        public const string URL = "ui://nj16dzxym3gh12";

        public static goto_btn CreateInstance()
        {
            return (goto_btn)UIPackage.CreateObject("fun_Florist", "goto_btn");
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