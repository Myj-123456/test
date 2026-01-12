/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class greenPicBtn : GButton
    {
        public GImage n9;
        public GLoader pic;
        public GTextField titleLab;
        public const string URL = "ui://udmgdnw2p2vh1yjp871";

        public static greenPicBtn CreateInstance()
        {
            return (greenPicBtn)UIPackage.CreateObject("fun_CultivateSeeds", "greenPicBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}