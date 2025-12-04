/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerArrangement
{
    public partial class materialListNew : GComponent
    {
        public Controller type;
        public materiel_itemNew flower_1;
        public materiel_itemNew flower_2;
        public materiel_itemNew flower_3;
        public materiel_itemNew flower_4;
        public const string URL = "ui://6kofjj39qarjp35";

        public static materialListNew CreateInstance()
        {
            return (materialListNew)UIPackage.CreateObject("fun_FlowerArrangement", "materialListNew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            flower_1 = (materiel_itemNew)GetChildAt(0);
            flower_2 = (materiel_itemNew)GetChildAt(1);
            flower_3 = (materiel_itemNew)GetChildAt(2);
            flower_4 = (materiel_itemNew)GetChildAt(3);
        }
    }
}