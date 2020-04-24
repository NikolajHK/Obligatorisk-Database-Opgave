using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext
{
    public interface iManageFaciliteter
    {
        List<ModelKlasser.Faciliteter> GetAllFaciliteter();

        ModelKlasser.Faciliteter GetFaciliteterFromId(int facilitetID);

        bool CreateFacilitetet(ModelKlasser.Faciliteter facilitet);

        bool UpdateFacilitet(int facilitetID, Faciliteter facilitet);

        ModelKlasser.Faciliteter DeleteFacilitet(int FacilitetID);


    }
    
}
