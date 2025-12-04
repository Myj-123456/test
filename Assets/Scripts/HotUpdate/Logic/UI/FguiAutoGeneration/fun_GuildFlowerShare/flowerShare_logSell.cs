/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_logSell : GComponent
    {
        public GRichTextField lb_info;
        public const string URL = "ui://zuzhxc13s3bkpnu";

        public static flowerShare_logSell CreateInstance()
        {
            return (flowerShare_logSell)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_logSell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            lb_info = (GRichTextField)GetChildAt(0);
        }
    }
}