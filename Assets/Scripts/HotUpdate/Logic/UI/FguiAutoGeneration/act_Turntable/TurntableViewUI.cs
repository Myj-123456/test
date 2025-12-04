/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace act_Turntable
{
    public partial class TurntableViewUI : GComponent
    {
        public GImage n17;
        public GTextInput input_name;
        public GImage n19;
        public GGraph holder;
        public const string URL = "ui://6kz12i2sgmqqs5";

        public static TurntableViewUI CreateInstance()
        {
            return (TurntableViewUI)UIPackage.CreateObject("act_Turntable", "TurntableViewUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n17 = (GImage)GetChildAt(0);
            input_name = (GTextInput)GetChildAt(1);
            n19 = (GImage)GetChildAt(2);
            holder = (GGraph)GetChildAt(3);
        }
    }
}