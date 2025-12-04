/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class nature_item_txt : GComponent
    {
        public GTextField natureLab;
        public const string URL = "ui://44kfvb3rm3gh46";

        public static nature_item_txt CreateInstance()
        {
            return (nature_item_txt)UIPackage.CreateObject("fun_FlowerGold", "nature_item_txt");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            natureLab = (GTextField)GetChildAt(0);
        }
    }
}