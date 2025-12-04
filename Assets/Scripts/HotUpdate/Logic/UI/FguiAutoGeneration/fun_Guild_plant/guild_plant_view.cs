/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class guild_plant_view : GComponent
    {
        public GLoader bg;
        public GButton close_btn;
        public GList list;
        public GImage n1;
        public GTextField titleLab;
        public GImage n9;
        public GLoader icon;
        public GButton helpBtn;
        public GTextField numLab;
        public GGroup n16;
        public const string URL = "ui://qfpad3q0tewh1";

        public static guild_plant_view CreateInstance()
        {
            return (guild_plant_view)UIPackage.CreateObject("fun_Guild_plant", "guild_plant_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            list = (GList)GetChildAt(2);
            n1 = (GImage)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
            n9 = (GImage)GetChildAt(5);
            icon = (GLoader)GetChildAt(6);
            helpBtn = (GButton)GetChildAt(7);
            numLab = (GTextField)GetChildAt(8);
            n16 = (GGroup)GetChildAt(9);
        }
    }
}