/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class FloatHurt : GComponent
    {
        public Controller c1;
        public GTextField txt_damage;
        public GTextField txt_critDamage;
        public GTextField txt_cure;
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public const string URL = "ui://z1b78orpf3ot0";

        public static FloatHurt CreateInstance()
        {
            return (FloatHurt)UIPackage.CreateObject("fun_Battle", "FloatHurt");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            txt_damage = (GTextField)GetChildAt(0);
            txt_critDamage = (GTextField)GetChildAt(1);
            txt_cure = (GTextField)GetChildAt(2);
            n1 = (GImage)GetChildAt(3);
            n2 = (GImage)GetChildAt(4);
            n3 = (GImage)GetChildAt(5);
            n4 = (GImage)GetChildAt(6);
            n5 = (GImage)GetChildAt(7);
            n6 = (GImage)GetChildAt(8);
        }
    }
}