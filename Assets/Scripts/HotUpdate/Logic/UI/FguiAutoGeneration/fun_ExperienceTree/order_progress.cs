/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ExperienceTree
{
    public partial class order_progress : GProgressBar
    {
        public GImage bar;
        public const string URL = "ui://w2l4gzffqhebk";

        public static order_progress CreateInstance()
        {
            return (order_progress)UIPackage.CreateObject("fun_ExperienceTree", "order_progress");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bar = (GImage)GetChildAt(0);
        }
    }
}