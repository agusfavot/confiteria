namespace EntityLayer
{
    public class Item
    {
        private int id;
        private string name;
        private string description;
        private float price;
        private int idSector;

        public Item(int id, string name, string description, float price, int idSector) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.idSector = idSector;
        }
        public Item(string name, string description, float price, int idSector)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.idSector = idSector;
        }


        public Item() { }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public float Price { get => price; set => price = value; }
        public int IdSector { get => idSector; set => idSector = value; }
    }
}
