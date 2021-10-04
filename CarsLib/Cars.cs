using System;

namespace CarsLib
{
    public class Cars
    {
        public string Rego { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int yearOfManufacture { get; set; }
        public int Speed { get; set; }
        public int NewSpeed { get; set; }
        
        public Cars(string _rego, string _make, string _model,int YOM,  int _speed)
        {
            this.Rego = _rego;
            this.Make = _make;
            this.Model = _model;
            this.yearOfManufacture = YOM;
            this.Speed = _speed;
      
        }
                //increases the speed of a Car Cannot exceed 150.  If negative number is given, change it to positive
                public int increaseSpeed(int increaseAmount)
                {
                    int MaxSpeed = 150;

                    if (increaseAmount < 0)
                    {
                        increaseAmount = 0;
                    }

                    this.Speed += increaseAmount;
                    

                    if ( this.Speed > MaxSpeed )
                    {
                        this.Speed = MaxSpeed;
                    }
                    
                    return this.Speed;
                }

                    // decreases the speed of a Car.  Cannot go below 0.  If negative number is given, change it to positive
                   public int DecreaseSpeed(int deceleratedSpeed)
                    {
                        int MinSpeed = 0;

                        if ( deceleratedSpeed < 0 )
                        {
                            deceleratedSpeed = 0;
                        }

                        this.Speed -= deceleratedSpeed;

                        if ( this.Speed < MinSpeed )
                        {
                            this.Speed = MinSpeed;
                        }

                        return this.Speed;
                    }

                    // Gets the current age by year of the the car based on current year and year of manufacture.  *Hint use DateTime.Now
                    public int GetAge()
                    {
                       int CurrentYear = DateTime.Now.Year;

                       int age = (CurrentYear - this.yearOfManufacture);

                        return age;
                    }

    }
}
