using System.ComponentModel.DataAnnotations;

namespace Day1API.Validators
{
    public class DateMustBeInPastAttribute :ValidationAttribute
    {

        public override bool IsValid(object? value)

        { return value is DateTime productionDate && productionDate < DateTime.Now; }
        //  => value is DateTime productionDate && productionDate < DateTime.Now;
        
    }
}
