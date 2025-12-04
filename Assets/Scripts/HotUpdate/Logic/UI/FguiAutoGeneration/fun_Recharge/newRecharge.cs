/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class newRecharge : GComponent
    {
        public GLoader bg;
        public GLoader bg1;
        public GLoader bg2;
        public GLoader bg3;
        public GImage n25;
        public recharge_list revharge;
        public GGraph rect;
        public GLoader3D spine;
        public const string URL = "ui://w3ox9yltqheb0";

        public static newRecharge CreateInstance()
        {
            return (newRecharge)UIPackage.CreateObject("fun_Recharge", "newRecharge");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            bg2 = (GLoader)GetChildAt(2);
            bg3 = (GLoader)GetChildAt(3);
            n25 = (GImage)GetChildAt(4);
            revharge = (recharge_list)GetChildAt(5);
            rect = (GGraph)GetChildAt(6);
            spine = (GLoader3D)GetChildAt(7);
        }
    }
}