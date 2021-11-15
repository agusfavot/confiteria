using EntityLayer;
using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ItemBL
    {
        #region
        private static ItemBL itemBL = null;
        private ItemBL() { }

        public static ItemBL getInstance()
        {
            return itemBL == null ? new ItemBL() : itemBL;
        }
        #endregion

        public int newItem(Item item)
        {
            return AccessArticleData.getInstance().insertArticle(new Dictionary<object, object> { { "name", item.Name }, { "@description", item.Description }, { "@price", item.Price }, {"@idSector", item.IdSector } });
        }

        public int editItem(Item item)
        {
            return AccessArticleData.getInstance().updateArticle(new Dictionary<object, object> { { "@id", item.Id }, { "name", item.Name }, { "@description", item.Description }, { "@price", item.Price }, { "@idSector", item.IdSector } });
        }

        public int removeItem(int id)
        {
            return AccessArticleData.getInstance().deleteArticle(new Dictionary<object, object> { { "@id", id } });
        }

        public List<Item> searAllArticles() {
            return AccessArticleData.getInstance().searAllArticles();
        }
    }
}
