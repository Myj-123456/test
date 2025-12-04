/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class reward_item : GComponent
    {
        public GLoader bg;
        public GLoader icon;
        public GTextField numLab;
        public const string URL = "ui://qfpad3q0tewh9";

        public static reward_item CreateInstance()
        {
            return (reward_item)UIPackage.CreateObject("fun_Guild_plant", "reward_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
        }
    }
}