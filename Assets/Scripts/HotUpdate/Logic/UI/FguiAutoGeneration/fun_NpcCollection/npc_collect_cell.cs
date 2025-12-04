/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcCollection
{
    public partial class npc_collect_cell : GComponent
    {
        public GImage n1;
        public GList list;
        public const string URL = "ui://ydpeia1vu0i3d";

        public static npc_collect_cell CreateInstance()
        {
            return (npc_collect_cell)UIPackage.CreateObject("fun_NpcCollection", "npc_collect_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            list = (GList)GetChildAt(1);
        }
    }
}