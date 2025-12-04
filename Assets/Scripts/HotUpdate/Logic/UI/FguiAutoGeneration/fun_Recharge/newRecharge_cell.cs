/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class newRecharge_cell : GComponent
    {
        public Controller preferentialTab;
        public GImage n1;
        public GLoader img_loader;
        public GLoader3D spine;
        public GLoader3D spine1;
        public GImage n7;
        public GTextField txt_value;
        public GTextField costLab;
        public GTextField costLab1;
        public GTextField extraTxt;
        public GTextField double_txt_value;
        public const string URL = "ui://w3ox9yltqhebq";

        public static newRecharge_cell CreateInstance()
        {
            return (newRecharge_cell)UIPackage.CreateObject("fun_Recharge", "newRecharge_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            preferentialTab = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            img_loader = (GLoader)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            spine1 = (GLoader3D)GetChildAt(3);
            n7 = (GImage)GetChildAt(4);
            txt_value = (GTextField)GetChildAt(5);
            costLab = (GTextField)GetChildAt(6);
            costLab1 = (GTextField)GetChildAt(7);
            extraTxt = (GTextField)GetChildAt(8);
            double_txt_value = (GTextField)GetChildAt(9);
        }
    }
}