/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerArrangement
{
    public partial class makeEffect : GComponent
    {
        public Controller makeOver;
        public Controller status;
        public GGraph hit;
        public GLoader3D spine1;
        public GComponent img_ike;
        public GImage title;
        public GLoader3D spine2;
        public GLoader3D spine3;
        public GButton btn_complete1;
        public GButton btn_share;
        public GGraph share_area;
        public GTextField tipLab;
        public Transition anim;
        public const string URL = "ui://6kofjj39gzzirr";

        public static makeEffect CreateInstance()
        {
            return (makeEffect)UIPackage.CreateObject("fun_FlowerArrangement", "makeEffect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            makeOver = GetControllerAt(0);
            status = GetControllerAt(1);
            hit = (GGraph)GetChildAt(0);
            spine1 = (GLoader3D)GetChildAt(1);
            img_ike = (GComponent)GetChildAt(2);
            title = (GImage)GetChildAt(3);
            spine2 = (GLoader3D)GetChildAt(4);
            spine3 = (GLoader3D)GetChildAt(5);
            btn_complete1 = (GButton)GetChildAt(6);
            btn_share = (GButton)GetChildAt(7);
            share_area = (GGraph)GetChildAt(8);
            tipLab = (GTextField)GetChildAt(9);
            anim = GetTransitionAt(0);
        }
    }
}