using EntityLayer;
using DataAccessLayer;
using System.Collections.Generic;


namespace BusinessLayer
{
    public class SectorBL
    {
        #region
        private static SectorBL sectorBL = null;
        private SectorBL() { }
        public static SectorBL getInstance()
        {
            return sectorBL == null ? new SectorBL() : sectorBL;
        }
        #endregion

        public int newSector(Sector sector)
        {
            return AccessSectorData.getInstance().insertSector(new Dictionary<object, object> { { "name", sector.Name } });
        }

        public int editSector(Sector sector)
        {
            return AccessSectorData.getInstance().updateSector(new Dictionary<object, object> { { "@id", sector.Id }, { "name", sector.Name } });
        }

        public int removeSector(int id)
        {
            return AccessSectorData.getInstance().deleteSector(new Dictionary<object, object> { { "@id", id } });
        }

        public List<Sector> searchAllSector() 
        {
            return AccessSectorData.getInstance().searchAllSector();
        }
    }
}
