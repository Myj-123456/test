/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_LevelUp
{
    public partial class share_item : GComponent
    {
        public GLoader pic;
        public GTextField number;
        public const string URL = "ui://zxpmd1qw10vyr1ayr8d1";

        public static share_item CreateInstance()
        {
            return (share_item)UIPackage.CreateObject("fun_LevelUp", "share_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pic = (GLoader)GetChildAt(0);
            number = (GTextField)GetChildAt(1);
        }
    }
}