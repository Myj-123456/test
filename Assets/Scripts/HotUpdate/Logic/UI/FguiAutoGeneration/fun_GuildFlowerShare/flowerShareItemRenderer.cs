/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShareItemRenderer : GComponent
    {
        public GImage n7;
        public GList list;
        public flowerShareHead playerHead;
        public const string URL = "ui://zuzhxc13s3bkpno";

        public static flowerShareItemRenderer CreateInstance()
        {
            return (flowerShareItemRenderer)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShareItemRenderer");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n7 = (GImage)GetChildAt(0);
            list = (GList)GetChildAt(1);
            playerHead = (flowerShareHead)GetChildAt(2);
        }
    }
}