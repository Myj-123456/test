/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_cell_4 : GComponent
    {
        public GImage n6;
        public GLoader img_flower;
        public GRichTextField lb_count;
        public const string URL = "ui://zuzhxc13s3bkpo6";

        public static flowerShare_cell_4 CreateInstance()
        {
            return (flowerShare_cell_4)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_cell_4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            img_flower = (GLoader)GetChildAt(1);
            lb_count = (GRichTextField)GetChildAt(2);
        }
    }
}