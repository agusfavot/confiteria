namespace EntityLayer
{
    public class Detail
    {
        private int idTicket;
        private int nroItem;
        private int idArticle;
        private float price;

        public Detail(int idTicket, int nroItem, int idArticle, float price) {
            this.idTicket = idTicket;
            this.nroItem = nroItem;
            this.idArticle = idArticle;
            this.price = price;
        }

        public Detail() { }

        public int IdTiecket { get => idTicket; set => idTicket = value; }
        public int NroItem { get => nroItem; set => nroItem = value; }
        public int IdArticle{ get => idArticle; set => idArticle = value; }
        public float Price { get => price; set => price = value; }
    }
}
