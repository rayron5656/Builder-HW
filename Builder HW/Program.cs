using System;

namespace Builder_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            VacationBuilder V5 = new StarBuilder();
            V5.ConstructVacation();
            var FiveStar = V5.GetVacation();

            VacationBuilder LowcostBuilder = new LowCostBuilder();
            LowcostBuilder.ConstructVacation();
            var Lowcost  = LowcostBuilder.GetVacation();


            var FluentBuilder = new FluentVacBuilder(true);
            
            var FiveCost = FluentBuilder.Constract();
            var FluentBuilder2 = new FluentVacBuilder(false);
            
            var LowCost2 = FluentBuilder2.Constract();

        }
    }

    public class VacForFluent
    {
        public string Hotel { get; set; }
        public string Flight { get; set; }
        public string Transsport { get; set; }

        public VacForFluent(string hotel, string flight, string transsport)
        {
            Hotel = hotel;
            Flight = flight;
            Transsport = transsport;
        }
    }

    public class FluentVacBuilder
    {
        private VacForFluent vacation = new VacForFluent("", "", "");
        private bool FiveStar;

        public FluentVacBuilder(bool fiveStar)
        {
            FiveStar = fiveStar;
        }

        public FluentVacBuilder Hotel()
        {
            if (FiveStar)
            {
                vacation.Hotel = "5 Star";
            }
            else
            {
                vacation.Hotel = "3 Star";
            }
            
            return this;
        }

        public FluentVacBuilder Flight()
        {
            if (FiveStar)
            {
                vacation.Flight = "First Class";
            }
            else
            {
                vacation.Flight = "Coach";
            }

            return this;
        }

        public FluentVacBuilder Transsport()
        {
            if (FiveStar)
            {
                vacation.Transsport = "Limo Driver";
            }
            else
            {
                vacation.Transsport = "Bus Driver";
            }
           

            return this;
        }

        public VacForFluent Constract()
        {
            Flight().Transsport().Hotel();
            return vacation;
        }


        
        

    }

    public abstract class VacationBuilder
    {
        protected Vacation vacation;

        public VacationBuilder()
        {
            vacation = new Vacation();
        }

        public abstract void SetFlight();

        public abstract void SetTranssport();

        public abstract void SetHotel();

       

        public void ConstructVacation()
        {
            SetFlight();
            SetTranssport();
           
            SetHotel();

        }

        public Vacation GetVacation() 
        {
            return vacation;
        }
    }

    public class Vacation
    {
        private string Flight;
        private string Transsport;
        private string Hotel;
        

        public void SetFlight(string flight)
        {
            Flight = flight;
        }

        public void SetTranssport(string transsport)
        {
            Transsport = transsport;
        }

        public void SetHotel(string hotel)
        {
            Hotel = hotel;
        }

        
    }

    public class StarBuilder : VacationBuilder
    {
        public override void SetFlight()
        {
            vacation.SetFlight("First Class");
        }

        public override void SetHotel()
        {
            vacation.SetHotel("5 Stars");
        }

        public override void SetTranssport()
        {
            vacation.SetTranssport("Limo transsport");
        }
    }

    public class LowCostBuilder : VacationBuilder
    {
        public override void SetFlight()
        {
            vacation.SetFlight("Coach flight");
        }

        public override void SetHotel()
        {
            vacation.SetHotel("3 Start Hotel");
        }

        public override void SetTranssport()
        {
            vacation.SetTranssport("Bus transsport");
        }
    }

}
