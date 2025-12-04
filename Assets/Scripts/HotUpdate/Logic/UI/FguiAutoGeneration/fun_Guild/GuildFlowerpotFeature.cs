/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class GuildFlowerpotFeature : GComponent
    {
        public GLoader pot;
        public GTextField lvTxt;
        public GRichTextField featureTxt;
        public const string URL = "ui://6wv667gu6pbpphe";

        public static GuildFlowerpotFeature CreateInstance()
        {
            return (GuildFlowerpotFeature)UIPackage.CreateObject("fun_Guild", "GuildFlowerpotFeature");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pot = (GLoader)GetChildAt(0);
            lvTxt = (GTextField)GetChildAt(1);
            featureTxt = (GRichTextField)GetChildAt(2);
        }
    }
}