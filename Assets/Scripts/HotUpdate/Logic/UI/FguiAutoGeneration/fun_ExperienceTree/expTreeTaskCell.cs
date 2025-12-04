/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ExperienceTree
{
    public partial class expTreeTaskCell : GComponent
    {
        public GImage n1;
        public GImage n4;
        public GRichTextField taskName;
        public GRichTextField per;
        public const string URL = "ui://w2l4gzffqhebj";

        public static expTreeTaskCell CreateInstance()
        {
            return (expTreeTaskCell)UIPackage.CreateObject("fun_ExperienceTree", "expTreeTaskCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            taskName = (GRichTextField)GetChildAt(2);
            per = (GRichTextField)GetChildAt(3);
        }
    }
}