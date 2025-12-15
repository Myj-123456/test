/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class first_tip2 : GComponent
    {
        public GImage n8;
        public GLoader show_btn;
        public GTextField nameLab;
        public const string URL = "ui://w3ox9yltdhbs1yjp85o";

        public static first_tip2 CreateInstance()
        {
            return (first_tip2)UIPackage.CreateObject("fun_Recharge", "first_tip2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n8 = (GImage)GetChildAt(0);
            show_btn = (GLoader)GetChildAt(1);
            nameLab = (GTextField)GetChildAt(2);
        }
    }
}