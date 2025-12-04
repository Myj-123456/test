/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class match_flower_item : GComponent
    {
        public GLoader bg;
        public GLoader pic;
        public const string URL = "ui://qefze8qir0nz3p";

        public static match_flower_item CreateInstance()
        {
            return (match_flower_item)UIPackage.CreateObject("fun_Guild_Match", "match_flower_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
        }
    }
}