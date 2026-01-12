/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcCollection
{
    public partial class ProgressBar : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public GTextField proLab;
        public const string URL = "ui://ydpeia1vplz71p";

        public static ProgressBar CreateInstance()
        {
            return (ProgressBar)UIPackage.CreateObject("fun_NpcCollection", "ProgressBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
            proLab = (GTextField)GetChildAt(2);
        }
    }
}