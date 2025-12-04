/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class flower : GComponent
    {
        public GImage n1;
        public GList itemList;
        public GGraph n4;
        public Transition open;
        public Transition close;
        public const string URL = "ui://udmgdnw2q9bj1ayr86o";

        public static flower CreateInstance()
        {
            return (flower)UIPackage.CreateObject("fun_CultivateSeeds", "flower");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            itemList = (GList)GetChildAt(1);
            n4 = (GGraph)GetChildAt(2);
            open = GetTransitionAt(0);
            close = GetTransitionAt(1);
        }
    }
}