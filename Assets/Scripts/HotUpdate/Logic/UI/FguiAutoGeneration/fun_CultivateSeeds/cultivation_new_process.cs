/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class cultivation_new_process : GProgressBar
    {
        public GImage n1;
        public GImage bar;
        public const string URL = "ui://udmgdnw2s23e1ayr868";

        public static cultivation_new_process CreateInstance()
        {
            return (cultivation_new_process)UIPackage.CreateObject("fun_CultivateSeeds", "cultivation_new_process");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}