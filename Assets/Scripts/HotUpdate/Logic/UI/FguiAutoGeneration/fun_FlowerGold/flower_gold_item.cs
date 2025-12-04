/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class flower_gold_item : GComponent
    {
        public Controller have;
        public Controller status;
        public GLoader3D spine;
        public GLoader icon;
        public GLoader bg;
        public GLoader rare_img;
        public GImage n13;
        public GImage n17;
        public shard__item com;
        public GTextField nameLab;
        public GTextField haveNum;
        public GTextField haveLab;
        public GButton detail_btn;
        public Transition ball;
        public Transition floated;
        public Transition fadeIn;
        public Transition fadeOut;
        public const string URL = "ui://44kfvb3rx92m36";

        public static flower_gold_item CreateInstance()
        {
            return (flower_gold_item)UIPackage.CreateObject("fun_FlowerGold", "flower_gold_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            have = GetControllerAt(0);
            status = GetControllerAt(1);
            spine = (GLoader3D)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            bg = (GLoader)GetChildAt(2);
            rare_img = (GLoader)GetChildAt(3);
            n13 = (GImage)GetChildAt(4);
            n17 = (GImage)GetChildAt(5);
            com = (shard__item)GetChildAt(6);
            nameLab = (GTextField)GetChildAt(7);
            haveNum = (GTextField)GetChildAt(8);
            haveLab = (GTextField)GetChildAt(9);
            detail_btn = (GButton)GetChildAt(10);
            ball = GetTransitionAt(0);
            floated = GetTransitionAt(1);
            fadeIn = GetTransitionAt(2);
            fadeOut = GetTransitionAt(3);
        }
    }
}