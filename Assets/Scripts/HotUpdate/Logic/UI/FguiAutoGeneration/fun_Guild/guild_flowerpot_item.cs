/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_flowerpot_item : GComponent
    {
        public Controller state;
        public Controller upgradeTab;
        public GLoader defaultPot;
        public GImage n54;
        public GButton unlockBtn;
        public GImage n47;
        public GTextField unlockTipTxt;
        public GGroup unlockTipGroup;
        public GGroup unlockGroup;
        public GLoader flowerpotLoader;
        public GLoader plantLoader;
        public GImage n50;
        public GRichTextField storageTxt;
        public GGroup n37;
        public GComponent flowerHitArea;
        public btn_add add_btn;
        public btn_level upgradeBtn;
        public GButton upgradeBtn1;
        public GGraph potHitArea;
        public GGroup commonGroup;
        public GImage n51;
        public GRichTextField lvTxt;
        public GGroup n45;
        public GImage n56;
        public GTextField cdTxt;
        public const string URL = "ui://6wv667guhxk4pgv";

        public static guild_flowerpot_item CreateInstance()
        {
            return (guild_flowerpot_item)UIPackage.CreateObject("fun_Guild", "guild_flowerpot_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            upgradeTab = GetControllerAt(1);
            defaultPot = (GLoader)GetChildAt(0);
            n54 = (GImage)GetChildAt(1);
            unlockBtn = (GButton)GetChildAt(2);
            n47 = (GImage)GetChildAt(3);
            unlockTipTxt = (GTextField)GetChildAt(4);
            unlockTipGroup = (GGroup)GetChildAt(5);
            unlockGroup = (GGroup)GetChildAt(6);
            flowerpotLoader = (GLoader)GetChildAt(7);
            plantLoader = (GLoader)GetChildAt(8);
            n50 = (GImage)GetChildAt(9);
            storageTxt = (GRichTextField)GetChildAt(10);
            n37 = (GGroup)GetChildAt(11);
            flowerHitArea = (GComponent)GetChildAt(12);
            add_btn = (btn_add)GetChildAt(13);
            upgradeBtn = (btn_level)GetChildAt(14);
            upgradeBtn1 = (GButton)GetChildAt(15);
            potHitArea = (GGraph)GetChildAt(16);
            commonGroup = (GGroup)GetChildAt(17);
            n51 = (GImage)GetChildAt(18);
            lvTxt = (GRichTextField)GetChildAt(19);
            n45 = (GGroup)GetChildAt(20);
            n56 = (GImage)GetChildAt(21);
            cdTxt = (GTextField)GetChildAt(22);
        }
    }
}