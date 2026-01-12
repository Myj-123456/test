/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class btn1 : GButton
    {
        public GImage n9;
        public GTextField titleLab;
        public const string URL = "ui://udmgdnw2s23el";

        public static btn1 CreateInstance()
        {
            return (btn1)UIPackage.CreateObject("fun_CultivateSeeds", "btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}