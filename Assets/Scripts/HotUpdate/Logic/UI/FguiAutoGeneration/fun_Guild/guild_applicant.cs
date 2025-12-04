/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_applicant : GComponent
    {
        public GList list_applicant;
        public GButton btn_refuseAll;
        public const string URL = "ui://6wv667gulmnhpde";

        public static guild_applicant CreateInstance()
        {
            return (guild_applicant)UIPackage.CreateObject("fun_Guild", "guild_applicant");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list_applicant = (GList)GetChildAt(0);
            btn_refuseAll = (GButton)GetChildAt(1);
        }
    }
}