/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class newRecharge_cell : GComponent
    {
        public Controller preferentialTab;
        public GImage n17;
        public GLoader img_loader;
        public GLoader3D spine;
        public GImage n18;
        public GTextField double_txt_value;
        public GTextField txt_value;
        public GButton n16;
        public GImage n19;
        public GTextField extraTxt;
        public const string URL = "ui://w3ox9yltqhebq";

        public static newRecharge_cell CreateInstance()
        {
            return (newRecharge_cell)UIPackage.CreateObject("fun_Recharge", "newRecharge_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            preferentialTab = GetControllerAt(0);
            n17 = (GImage)GetChildAt(0);
            img_loader = (GLoader)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            n18 = (GImage)GetChildAt(3);
            double_txt_value = (GTextField)GetChildAt(4);
            txt_value = (GTextField)GetChildAt(5);
            n16 = (GButton)GetChildAt(6);
            n19 = (GImage)GetChildAt(7);
            extraTxt = (GTextField)GetChildAt(8);
        }
    }
}