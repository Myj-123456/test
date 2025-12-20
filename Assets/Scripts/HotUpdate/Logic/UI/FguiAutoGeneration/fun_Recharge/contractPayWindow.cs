/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class contractPayWindow : GComponent
    {
        public Controller show;
        public GLoader bg;
        public GImage n76;
        public GImage n77;
        public GImage n78;
        public GImage n79;
        public GTextField tipLab1;
        public GImage n81;
        public GTextField advFlowerNameLab;
        public GImage n83;
        public GTextField superFlowerNameLab;
        public GButton advPayBtn;
        public GButton superPayBtn;
        public GTextField tipLab;
        public Transition anim;
        public const string URL = "ui://w3ox9yltm8ja1yjp886";

        public static contractPayWindow CreateInstance()
        {
            return (contractPayWindow)UIPackage.CreateObject("fun_Recharge", "contractPayWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            show = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n76 = (GImage)GetChildAt(1);
            n77 = (GImage)GetChildAt(2);
            n78 = (GImage)GetChildAt(3);
            n79 = (GImage)GetChildAt(4);
            tipLab1 = (GTextField)GetChildAt(5);
            n81 = (GImage)GetChildAt(6);
            advFlowerNameLab = (GTextField)GetChildAt(7);
            n83 = (GImage)GetChildAt(8);
            superFlowerNameLab = (GTextField)GetChildAt(9);
            advPayBtn = (GButton)GetChildAt(10);
            superPayBtn = (GButton)GetChildAt(11);
            tipLab = (GTextField)GetChildAt(12);
            anim = GetTransitionAt(0);
        }
    }
}