/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GetReward
{
    public partial class getReward_list : GComponent
    {
        public GList list;
        public GGraph n1;
        public const string URL = "ui://j0e2l4ppnqrs1yjp7sd";

        public static getReward_list CreateInstance()
        {
            return (getReward_list)UIPackage.CreateObject("fun_GetReward", "getReward_list");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list = (GList)GetChildAt(0);
            n1 = (GGraph)GetChildAt(1);
        }
    }
}