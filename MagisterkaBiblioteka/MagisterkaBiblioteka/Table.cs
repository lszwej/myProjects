namespace MagisterkaBiblioteka
{
    public class Table
    {
        private string name;

        public Table(Table tab)
        {
            if (tab != null)
                name = tab.name ?? "";
        }

        public Table(string name)
        {
            this.name = name ?? "";
        }

        public string TableName
        {
            get { return name; }
        }

        public override string ToString()
        {
            return TableName;
        }
    }
}