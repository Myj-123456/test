/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class harvest : GComponent
    {
        public Controller type;
        public GLoader scissor;
        public const string URL = "ui://dpcxz2fid27x1a";

        public static harvest CreateInstance()
        {
            return (harvest)UIPackage.CreateObject("fun_Scene", "harvest");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            scissor = (GLoader)GetChildAt(0);
        }
    }
}