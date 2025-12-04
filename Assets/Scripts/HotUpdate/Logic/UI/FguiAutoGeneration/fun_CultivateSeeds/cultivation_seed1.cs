/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class cultivation_seed1 : GComponent
    {
        public Controller status;
        public Controller type;
        public GImage n29;
        public GLoader Img;
        public GTextField title_txt;
        public GTextField count_txt;
        public const string URL = "ui://udmgdnw2s23eu";

        public static cultivation_seed1 CreateInstance()
        {
            return (cultivation_seed1)UIPackage.CreateObject("fun_CultivateSeeds", "cultivation_seed1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            type = GetControllerAt(1);
            n29 = (GImage)GetChildAt(0);
            Img = (GLoader)GetChildAt(1);
            title_txt = (GTextField)GetChildAt(2);
            count_txt = (GTextField)GetChildAt(3);
        }
    }
}