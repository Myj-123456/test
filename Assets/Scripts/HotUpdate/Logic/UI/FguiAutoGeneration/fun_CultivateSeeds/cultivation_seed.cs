/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class cultivation_seed : GComponent
    {
        public GImage n24;
        public GLoader pic;
        public GImage n22;
        public GTextField name_txt;
        public const string URL = "ui://udmgdnw2s23es";

        public static cultivation_seed CreateInstance()
        {
            return (cultivation_seed)UIPackage.CreateObject("fun_CultivateSeeds", "cultivation_seed");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n24 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            n22 = (GImage)GetChildAt(2);
            name_txt = (GTextField)GetChildAt(3);
        }
    }
}