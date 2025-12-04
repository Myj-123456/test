/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class FightPetUnit : GComponent
    {
        public GLoader3D petModel;
        public const string URL = "ui://z1b78orpphdav";

        public static FightPetUnit CreateInstance()
        {
            return (FightPetUnit)UIPackage.CreateObject("fun_Battle", "FightPetUnit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            petModel = (GLoader3D)GetChildAt(0);
        }
    }
}