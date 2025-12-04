/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Player
{
    public partial class goto_btn : GButton
    {
        public GTextField titleLab;
        public const string URL = "ui://0svwl9suv5ljw";

        public static goto_btn CreateInstance()
        {
            return (goto_btn)UIPackage.CreateObject("fun_Player", "goto_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            titleLab = (GTextField)GetChildAt(0);
        }
    }
}