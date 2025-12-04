/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class tweenCom : GComponent
    {
        public flower flower;
        public GImage n2;
        public Transition right;
        public Transition left;
        public const string URL = "ui://udmgdnw2q9bj1ayr86q";

        public static tweenCom CreateInstance()
        {
            return (tweenCom)UIPackage.CreateObject("fun_CultivateSeeds", "tweenCom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            flower = (flower)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            right = GetTransitionAt(0);
            left = GetTransitionAt(1);
        }
    }
}