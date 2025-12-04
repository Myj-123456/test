/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class FightHeroUnit : GComponent
    {
        public BuffBar buffBar;
        public HeadBar headBar;
        public GLoader3D huibiModel;
        public EffectOrientation effectBack;
        public GLoader3D heroModel;
        public EffectOrientation effectFont;
        public const string URL = "ui://z1b78orpphdat";

        public static FightHeroUnit CreateInstance()
        {
            return (FightHeroUnit)UIPackage.CreateObject("fun_Battle", "FightHeroUnit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            buffBar = (BuffBar)GetChildAt(0);
            headBar = (HeadBar)GetChildAt(1);
            huibiModel = (GLoader3D)GetChildAt(2);
            effectBack = (EffectOrientation)GetChildAt(3);
            heroModel = (GLoader3D)GetChildAt(4);
            effectFont = (EffectOrientation)GetChildAt(5);
        }
    }
}