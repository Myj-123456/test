/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class yellow_btn : GButton
    {
        public GImage n9;
        public GLoader3D spine;
        public GTextField titleLab;
        public const string URL = "ui://w3ox9yltdhbs1yjp86a";

        public static yellow_btn CreateInstance()
        {
            return (yellow_btn)UIPackage.CreateObject("fun_Recharge", "yellow_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            spine = (GLoader3D)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}