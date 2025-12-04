/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class cultivation_seed2 : GComponent
    {
        public Controller status;
        public Controller type;
        public GImage n24;
        public GImage n29;
        public GImage n25;
        public GLoader Img;
        public GGraph costBtn;
        public GTextField title_txt;
        public GRichTextField count_txt;
        public const string URL = "ui://udmgdnw2s23e13";

        public static cultivation_seed2 CreateInstance()
        {
            return (cultivation_seed2)UIPackage.CreateObject("fun_CultivateSeeds", "cultivation_seed2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            type = GetControllerAt(1);
            n24 = (GImage)GetChildAt(0);
            n29 = (GImage)GetChildAt(1);
            n25 = (GImage)GetChildAt(2);
            Img = (GLoader)GetChildAt(3);
            costBtn = (GGraph)GetChildAt(4);
            title_txt = (GTextField)GetChildAt(5);
            count_txt = (GRichTextField)GetChildAt(6);
        }
    }
}