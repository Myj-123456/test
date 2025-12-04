/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class level_cost_item : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GImage n2;
        public GTextField addLab;
        public GTextField proLab;
        public const string URL = "ui://o7kmyysdx92m25";

        public static level_cost_item CreateInstance()
        {
            return (level_cost_item)UIPackage.CreateObject("fun_Pet", "level_cost_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            addLab = (GTextField)GetChildAt(3);
            proLab = (GTextField)GetChildAt(4);
        }
    }
}