/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class guild_plant_cell : GComponent
    {
        public Controller status;
        public GImage n1;
        public GGraph n14;
        public GImage n7;
        public GTextField extraLab;
        public GList reward_list;
        public GGroup extraGrp;
        public GImage n2;
        public GTextField indexLab;
        public GTextField nameLab;
        public GTextField timeLab;
        public GButton btn;
        public GTextField limitLab;
        public GImage n15;
        public const string URL = "ui://qfpad3q0tewh6";

        public static guild_plant_cell CreateInstance()
        {
            return (guild_plant_cell)UIPackage.CreateObject("fun_Guild_plant", "guild_plant_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n14 = (GGraph)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            extraLab = (GTextField)GetChildAt(3);
            reward_list = (GList)GetChildAt(4);
            extraGrp = (GGroup)GetChildAt(5);
            n2 = (GImage)GetChildAt(6);
            indexLab = (GTextField)GetChildAt(7);
            nameLab = (GTextField)GetChildAt(8);
            timeLab = (GTextField)GetChildAt(9);
            btn = (GButton)GetChildAt(10);
            limitLab = (GTextField)GetChildAt(11);
            n15 = (GImage)GetChildAt(12);
        }
    }
}