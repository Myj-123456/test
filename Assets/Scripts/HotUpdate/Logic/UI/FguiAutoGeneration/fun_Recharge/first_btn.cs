/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class first_btn : GComponent
    {
        public Controller status;
        public GImage getted_img;
        public GButton get_btn;
        public GImage n2;
        public const string URL = "ui://w3ox9yltdhbs1yjp85s";

        public static first_btn CreateInstance()
        {
            return (first_btn)UIPackage.CreateObject("fun_Recharge", "first_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            getted_img = (GImage)GetChildAt(0);
            get_btn = (GButton)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
        }
    }
}