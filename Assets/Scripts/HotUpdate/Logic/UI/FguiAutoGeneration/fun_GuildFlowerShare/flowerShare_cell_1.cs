/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_cell_1 : GComponent
    {
        public Controller sellstatus;
        public GImage n13;
        public GImage n14;
        public GLoader img_flower;
        public GRichTextField lb_count;
        public GImage n15;
        public GImage n10;
        public GImage n16;
        public GImage n12;
        public const string URL = "ui://zuzhxc13s3bkpnw";

        public static flowerShare_cell_1 CreateInstance()
        {
            return (flowerShare_cell_1)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_cell_1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            sellstatus = GetControllerAt(0);
            n13 = (GImage)GetChildAt(0);
            n14 = (GImage)GetChildAt(1);
            img_flower = (GLoader)GetChildAt(2);
            lb_count = (GRichTextField)GetChildAt(3);
            n15 = (GImage)GetChildAt(4);
            n10 = (GImage)GetChildAt(5);
            n16 = (GImage)GetChildAt(6);
            n12 = (GImage)GetChildAt(7);
        }
    }
}