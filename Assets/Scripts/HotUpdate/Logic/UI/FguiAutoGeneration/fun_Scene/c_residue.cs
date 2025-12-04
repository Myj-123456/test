/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class c_residue : GComponent
    {
        public GImage n0;
        public GImage n1;
        public GRichTextField times;
        public const string URL = "ui://dpcxz2finwd51i";

        public static c_residue CreateInstance()
        {
            return (c_residue)UIPackage.CreateObject("fun_Scene", "c_residue");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            times = (GRichTextField)GetChildAt(2);
        }
    }
}