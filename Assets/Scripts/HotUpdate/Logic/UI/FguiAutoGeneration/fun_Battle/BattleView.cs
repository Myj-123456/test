/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class BattleView : GComponent
    {
        public Controller c1;
        public GImage n20;
        public GImage n21;
        public BgView bg;
        public GButton btn_speedUp;
        public FightHeroUnit myHero;
        public FightHeroUnit otherHero;
        public FightPetUnit myPet0;
        public FightPetUnit myPet1;
        public FightPetUnit otherPet0;
        public FightPetUnit otherPet1;
        public FlowerFairiesItem myFairy0;
        public FlowerFairiesItem myFairy1;
        public FlowerFairiesItem myFairy2;
        public FlowerFairiesItem enmeyFairy0;
        public FlowerFairiesItem enmeyFairy1;
        public FlowerFairiesItem enmeyFairy2;
        public GGroup fairyGroup;
        public FightEnemyUnit enemy0;
        public FightEnemyUnit enemy1;
        public FightEnemyUnit enemy2;
        public GGroup enemyGroup;
        public GButton btn_back;
        public GRichTextField txt_skip;
        public GImage n18;
        public GTextField txt_round;
        public GLoader n23;
        public Transition t2;
        public const string URL = "ui://z1b78orpphdap";

        public static BattleView CreateInstance()
        {
            return (BattleView)UIPackage.CreateObject("fun_Battle", "BattleView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            n20 = (GImage)GetChildAt(0);
            n21 = (GImage)GetChildAt(1);
            bg = (BgView)GetChildAt(2);
            btn_speedUp = (GButton)GetChildAt(3);
            myHero = (FightHeroUnit)GetChildAt(4);
            otherHero = (FightHeroUnit)GetChildAt(5);
            myPet0 = (FightPetUnit)GetChildAt(6);
            myPet1 = (FightPetUnit)GetChildAt(7);
            otherPet0 = (FightPetUnit)GetChildAt(8);
            otherPet1 = (FightPetUnit)GetChildAt(9);
            myFairy0 = (FlowerFairiesItem)GetChildAt(10);
            myFairy1 = (FlowerFairiesItem)GetChildAt(11);
            myFairy2 = (FlowerFairiesItem)GetChildAt(12);
            enmeyFairy0 = (FlowerFairiesItem)GetChildAt(13);
            enmeyFairy1 = (FlowerFairiesItem)GetChildAt(14);
            enmeyFairy2 = (FlowerFairiesItem)GetChildAt(15);
            fairyGroup = (GGroup)GetChildAt(16);
            enemy0 = (FightEnemyUnit)GetChildAt(17);
            enemy1 = (FightEnemyUnit)GetChildAt(18);
            enemy2 = (FightEnemyUnit)GetChildAt(19);
            enemyGroup = (GGroup)GetChildAt(20);
            btn_back = (GButton)GetChildAt(21);
            txt_skip = (GRichTextField)GetChildAt(22);
            n18 = (GImage)GetChildAt(23);
            txt_round = (GTextField)GetChildAt(24);
            n23 = (GLoader)GetChildAt(25);
            t2 = GetTransitionAt(0);
        }
    }
}