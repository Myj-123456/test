/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class star_cost_item : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GTextField proLab;
        public const string URL = "ui://44kfvb3rm3gh1yjp813";

        public static star_cost_item CreateInstance()
        {
            return (star_cost_item)UIPackage.CreateObject("fun_FlowerGold", "star_cost_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            proLab = (GTextField)GetChildAt(2);
        }
    }
}