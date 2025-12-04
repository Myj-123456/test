/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class pet_call_show : GComponent
    {
        public Controller pos;
        public pet_call_item item1;
        public pet_call_item item2;
        public pet_call_item item3;
        public pet_call_item item4;
        public const string URL = "ui://o7kmyysdx92m2v";

        public static pet_call_show CreateInstance()
        {
            return (pet_call_show)UIPackage.CreateObject("fun_Pet", "pet_call_show");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pos = GetControllerAt(0);
            item1 = (pet_call_item)GetChildAt(0);
            item2 = (pet_call_item)GetChildAt(1);
            item3 = (pet_call_item)GetChildAt(2);
            item4 = (pet_call_item)GetChildAt(3);
        }
    }
}