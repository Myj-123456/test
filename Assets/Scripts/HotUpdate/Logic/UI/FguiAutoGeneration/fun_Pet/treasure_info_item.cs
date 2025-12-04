/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class treasure_info_item : GComponent
    {
        public GLoader bg;
        public GLoader icon;
        public GTextField proLab;
        public GTextField nameLab;
        public const string URL = "ui://o7kmyysdx92m18";

        public static treasure_info_item CreateInstance()
        {
            return (treasure_info_item)UIPackage.CreateObject("fun_Pet", "treasure_info_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            proLab = (GTextField)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
        }
    }
}