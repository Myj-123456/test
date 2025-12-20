/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class contractRewardPreview : GComponent
    {
        public Controller show;
        public GLoader bg;
        public GImage n61;
        public GImage n74;
        public GImage n75;
        public GLoader3D spine1;
        public GLoader3D spine2;
        public GTextField tipLab;
        public GList listleft;
        public GList listright;
        public GImage normalTitleBg;
        public GTextField normalTitleLab;
        public GButton buyBtn;
        public contractPreview_btn gaojiBtn;
        public contractPreview_btn zunxiangBtn;
        public GTextField flowerLab1;
        public GTextField flowerLab2;
        public Transition anim;
        public const string URL = "ui://w3ox9yltin5z1yjp87t";

        public static contractRewardPreview CreateInstance()
        {
            return (contractRewardPreview)UIPackage.CreateObject("fun_Recharge", "contractRewardPreview");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            show = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n61 = (GImage)GetChildAt(1);
            n74 = (GImage)GetChildAt(2);
            n75 = (GImage)GetChildAt(3);
            spine1 = (GLoader3D)GetChildAt(4);
            spine2 = (GLoader3D)GetChildAt(5);
            tipLab = (GTextField)GetChildAt(6);
            listleft = (GList)GetChildAt(7);
            listright = (GList)GetChildAt(8);
            normalTitleBg = (GImage)GetChildAt(9);
            normalTitleLab = (GTextField)GetChildAt(10);
            buyBtn = (GButton)GetChildAt(11);
            gaojiBtn = (contractPreview_btn)GetChildAt(12);
            zunxiangBtn = (contractPreview_btn)GetChildAt(13);
            flowerLab1 = (GTextField)GetChildAt(14);
            flowerLab2 = (GTextField)GetChildAt(15);
            anim = GetTransitionAt(0);
        }
    }
}