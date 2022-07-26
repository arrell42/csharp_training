using AutoIt;
namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITILE;
        protected AutoItX aux;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.aux = manager.Aux;
            WINTITILE = ApplicationManager.WINTITLE;

        }
    }
}