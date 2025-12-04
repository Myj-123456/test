/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class box_reward : GComponent
    {
        public Controller status;
        public GImage n2;
        public GImage n4;
        public GImage n3;
        public const string URL = "ui://oo5kr0yot5nhj";

        public static box_reward CreateInstance()
        {
            return (box_reward)UIPackage.CreateObject("fun_Tour_Land", "box_reward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
        }
    }
}