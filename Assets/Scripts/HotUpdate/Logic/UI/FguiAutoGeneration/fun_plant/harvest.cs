/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_plant
{
    public partial class harvest : GComponent
    {
        public Controller type;
        public GComponent help_btn;
        public GLoader scissor;
        public GComponent water;
        public GLoader btn_harvest;
        public const string URL = "ui://4905g7p7d27x1a";

        public static harvest CreateInstance()
        {
            return (harvest)UIPackage.CreateObject("fun_plant", "harvest");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            help_btn = (GComponent)GetChildAt(0);
            scissor = (GLoader)GetChildAt(1);
            water = (GComponent)GetChildAt(2);
            btn_harvest = (GLoader)GetChildAt(3);
        }
    }
}