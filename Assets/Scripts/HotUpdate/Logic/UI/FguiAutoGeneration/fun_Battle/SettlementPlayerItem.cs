/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class SettlementPlayerItem : GComponent
    {
        public GLoader img_head;
        public GLoader img_frame;
        public GTextField txt_name;
        public GRichTextField txt_score;
        public const string URL = "ui://z1b78orpin8ar30";

        public static SettlementPlayerItem CreateInstance()
        {
            return (SettlementPlayerItem)UIPackage.CreateObject("fun_Battle", "SettlementPlayerItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            img_head = (GLoader)GetChildAt(0);
            img_frame = (GLoader)GetChildAt(1);
            txt_name = (GTextField)GetChildAt(2);
            txt_score = (GRichTextField)GetChildAt(3);
        }
    }
}