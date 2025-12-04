/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class PictureFrame : GComponent
    {
        public Controller type;
        public GLoader pic;
        public GLoader3D anim;
        public const string URL = "ui://mjiw43v9e5f51yjp7rx";

        public static PictureFrame CreateInstance()
        {
            return (PictureFrame)UIPackage.CreateObject("common_New", "PictureFrame");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            pic = (GLoader)GetChildAt(0);
            anim = (GLoader3D)GetChildAt(1);
        }
    }
}