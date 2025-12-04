/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_cell_5 : GComponent
    {
        public GImage n3;
        public GLoader img_flower;
        public const string URL = "ui://zuzhxc13s3bkpo7";

        public static flowerShare_cell_5 CreateInstance()
        {
            return (flowerShare_cell_5)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_cell_5");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            img_flower = (GLoader)GetChildAt(1);
        }
    }
}