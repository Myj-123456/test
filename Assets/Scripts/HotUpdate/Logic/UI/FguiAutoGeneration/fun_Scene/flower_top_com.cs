/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class flower_top_com : GComponent
    {
        public flower_tip com;
        public Transition t0;
        public const string URL = "ui://dpcxz2fi9sto3d";

        public static flower_top_com CreateInstance()
        {
            return (flower_top_com)UIPackage.CreateObject("fun_Scene", "flower_top_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            com = (flower_tip)GetChildAt(0);
            t0 = GetTransitionAt(0);
        }
    }
}