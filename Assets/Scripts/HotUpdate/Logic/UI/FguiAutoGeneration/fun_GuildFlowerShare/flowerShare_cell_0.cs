/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_cell_0 : GComponent
    {
        public Controller sellstatus;
        public GImage n11;
        public GLoader img_flower;
        public GRichTextField lb_flowerCount;
        public GImage n5;
        public const string URL = "ui://zuzhxc13s3bkpnp";

        public static flowerShare_cell_0 CreateInstance()
        {
            return (flowerShare_cell_0)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_cell_0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            sellstatus = GetControllerAt(0);
            n11 = (GImage)GetChildAt(0);
            img_flower = (GLoader)GetChildAt(1);
            lb_flowerCount = (GRichTextField)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
        }
    }
}