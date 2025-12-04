/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class pet_call_item : GComponent
    {
        public Controller have;
        public GLoader quality_img;
        public GLoader icon;
        public GImage n2;
        public GImage n9;
        public GLoader rare_img;
        public GTextField nameLab;
        public GTextField haveLab;
        public GButton detail_btn;
        public GTextField shardLab;
        public const string URL = "ui://o7kmyysdx92m2a";

        public static pet_call_item CreateInstance()
        {
            return (pet_call_item)UIPackage.CreateObject("fun_Pet", "pet_call_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            have = GetControllerAt(0);
            quality_img = (GLoader)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
            rare_img = (GLoader)GetChildAt(4);
            nameLab = (GTextField)GetChildAt(5);
            haveLab = (GTextField)GetChildAt(6);
            detail_btn = (GButton)GetChildAt(7);
            shardLab = (GTextField)GetChildAt(8);
        }
    }
}