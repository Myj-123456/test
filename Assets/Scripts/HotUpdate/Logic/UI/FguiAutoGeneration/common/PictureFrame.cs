/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class PictureFrame : GComponent
    {
        public GLoader pic;
        public const string URL = "ui://6bdpq80knwgi1yjp7qj";

        public static PictureFrame CreateInstance()
        {
            return (PictureFrame)UIPackage.CreateObject("common", "PictureFrame");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pic = (GLoader)GetChildAt(0);
        }
    }
}