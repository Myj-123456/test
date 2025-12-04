/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_cell_3 : GComponent
    {
        public Controller status;
        public GImage n13;
        public GLoader img_flower;
        public GImage n14;
        public GImage n9;
        public GRichTextField lb_count;
        public GRichTextField lb_level;
        public const string URL = "ui://zuzhxc13s3bkpns";

        public static flowerShare_cell_3 CreateInstance()
        {
            return (flowerShare_cell_3)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_cell_3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n13 = (GImage)GetChildAt(0);
            img_flower = (GLoader)GetChildAt(1);
            n14 = (GImage)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
            lb_count = (GRichTextField)GetChildAt(4);
            lb_level = (GRichTextField)GetChildAt(5);
        }
    }
}