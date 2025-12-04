/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class nature_txt : GComponent
    {
        public GTextField attrLab;
        public const string URL = "ui://44kfvb3rm3gh4r";

        public static nature_txt CreateInstance()
        {
            return (nature_txt)UIPackage.CreateObject("fun_FlowerGold", "nature_txt");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            attrLab = (GTextField)GetChildAt(0);
        }
    }
}