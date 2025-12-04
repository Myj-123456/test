/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class handle_pgs : GProgressBar
    {
        public GTextField time;
        public const string URL = "ui://dpcxz2finwd51k";

        public static handle_pgs CreateInstance()
        {
            return (handle_pgs)UIPackage.CreateObject("fun_Scene", "handle_pgs");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            time = (GTextField)GetChildAt(0);
        }
    }
}