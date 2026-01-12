/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_LevelUp
{
    public partial class level_item : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GTextField number;
        public const string URL = "ui://zxpmd1qw10vyr1ayr8d0";

        public static level_item CreateInstance()
        {
            return (level_item)UIPackage.CreateObject("fun_LevelUp", "level_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            number = (GTextField)GetChildAt(2);
        }
    }
}