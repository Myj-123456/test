/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class pet_item : GButton
    {
        public Controller button;
        public GImage n1;
        public GImage n3;
        public GLoader pet_img;
        public const string URL = "ui://oo5kr0yot5nh12";

        public static pet_item CreateInstance()
        {
            return (pet_item)UIPackage.CreateObject("fun_Tour_Land", "pet_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            pet_img = (GLoader)GetChildAt(2);
        }
    }
}