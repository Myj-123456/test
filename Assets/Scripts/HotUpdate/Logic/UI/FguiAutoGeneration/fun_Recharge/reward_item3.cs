/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class reward_item3 : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public GTextField countLab;
        public const string URL = "ui://w3ox9yltv01m1ayr83l";

        public static reward_item3 CreateInstance()
        {
            return (reward_item3)UIPackage.CreateObject("fun_Recharge", "reward_item3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            countLab = (GTextField)GetChildAt(2);
        }
    }
}