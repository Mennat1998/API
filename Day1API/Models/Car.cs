using Day1API.Validators;
namespace Day1API.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Model { get; set; }=string.Empty;
        public int Price { get; set; }

        public string Type { get; set; }=string.Empty;

        //Validation [DateIsInPast]

        [DateMustBeInPast]
        public DateTime ProductionDate { get; set; } 

        public Car(int id, string name, string model, int price, string type ,DateTime productionDate)
        {
            Id = id;
            Name = name;
            Model = model;
            Price = price;
            Type = type;
            ProductionDate = productionDate;
        }
      
    }

}
