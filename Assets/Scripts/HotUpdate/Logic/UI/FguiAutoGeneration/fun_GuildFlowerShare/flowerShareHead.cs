/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShareHead : GComponent
    {
        public GImage n9;
        public GLoader img_head;
        public GComponent picFrame;
        public GRichTextField lb_townName;
        public const string URL = "ui://zuzhxc13s3bkpnq";

        public static flowerShareHead CreateInstance()
        {
            return (flowerShareHead)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShareHead");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            img_head = (GLoader)GetChildAt(1);
            picFrame = (GComponent)GetChildAt(2);
            lb_townName = (GRichTextField)GetChildAt(3);
        }
    }
}