/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class pre_pro_reward : GComponent
    {
        public GImage n1;
        public GList pro_list;
        public const string URL = "ui://qefze8qir0nz2t";

        public static pre_pro_reward CreateInstance()
        {
            return (pre_pro_reward)UIPackage.CreateObject("fun_Guild_Match", "pre_pro_reward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            pro_list = (GList)GetChildAt(1);
        }
    }
}