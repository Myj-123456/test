/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class cultivation_need_seed : GComponent
    {
        public Controller status;
        public GImage n28;
        public GImage n29;
        public GRichTextField needLab;
        public const string URL = "ui://udmgdnw2s23ev";

        public static cultivation_need_seed CreateInstance()
        {
            return (cultivation_need_seed)UIPackage.CreateObject("fun_CultivateSeeds", "cultivation_need_seed");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n28 = (GImage)GetChildAt(0);
            n29 = (GImage)GetChildAt(1);
            needLab = (GRichTextField)GetChildAt(2);
        }
    }
}