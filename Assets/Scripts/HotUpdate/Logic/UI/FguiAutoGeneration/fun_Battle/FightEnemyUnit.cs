/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class FightEnemyUnit : GComponent
    {
        public GLoader3D petModel;
        public BuffBar buffBar;
        public HeadBar headBar;
        public const string URL = "ui://z1b78orpz3t22t";

        public static FightEnemyUnit CreateInstance()
        {
            return (FightEnemyUnit)UIPackage.CreateObject("fun_Battle", "FightEnemyUnit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            petModel = (GLoader3D)GetChildAt(0);
            buffBar = (BuffBar)GetChildAt(1);
            headBar = (HeadBar)GetChildAt(2);
        }
    }
}