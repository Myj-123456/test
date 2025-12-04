/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class window_modal : GComponent
    {
        public GImage n2;
        public const string URL = "ui://6bdpq80kjpt91yjp7mf";

        public static window_modal CreateInstance()
        {
            return (window_modal)UIPackage.CreateObject("common", "window_modal");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
        }
    }
}