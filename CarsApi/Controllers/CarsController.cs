using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarsLib;
//using System.Text; //STEP 1 LINK FOLDER FOR DB https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive
using Database;


namespace CarsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
           
        public CarsData carsDB = new CarsData(); 
        public List<Cars> carsList = new List<Cars>();
        
        // This is called when the class is first created (Constructor)
        public CarsController() 
        {
            // (2) PopulateS this.BeersList with results from DB
            // (4) The return from this.beerDB.GetAllBeersFromDB() is stored in the class as this.BeersList
            this.carsList = this.carsDB.GetAllCarsFromDB(); //http can do any function now that it has data received from db
        }

        [HttpGet("AllCars")] 
        public List<Cars> GetAllCars() 
        {
            return this.carsList;
        }

        [HttpGet("CarByRego")]
        public Cars GetCarByRego(string lookupRego) 
        {
            foreach(Cars c in this.carsList ) 
            {
                if ( c.Rego == lookupRego )
                {
                    return c;
                } 
            }

            return null;
        }
    }
} 

   