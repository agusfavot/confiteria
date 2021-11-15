namespace EntityLayer
{
    public class Sector
    {
        private int id;
        private string name;

        public Sector(int id, string name) {
            this.id = id;
            this.name = name;
        }

        public Sector(string name)
        {
            this.name = name;
        }

        public Sector() { }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
