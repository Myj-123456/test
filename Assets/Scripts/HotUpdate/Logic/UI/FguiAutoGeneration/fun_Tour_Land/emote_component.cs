/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class emote_component : GComponent
    {
        public Controller status;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public const string URL = "ui://oo5kr0yox92m2j";

        public static emote_component CreateInstance()
        {
            return (emote_component)UIPackage.CreateObject("fun_Tour_Land", "emote_component");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
        }
    }
}