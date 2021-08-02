using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLL.DTOs
{
    /// <summary>
    /// This is a lite weight object to transfer data in the network
    /// </summary>
    public class EmployeeDto: IValidatableObject
    {
        public string FN { get;set;}
        public string MN { get; set; }
        public string LN { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(FN) && FN.Length>50)
            {
                yield return new ValidationResult("First Name should be maximum of 50 characters", new[] { "FN" });
            }
            if (!string.IsNullOrEmpty(MN) &&  MN.Length > 50)
            {
                yield return new ValidationResult("Middle Name should be maximum of 50 characters", new[] { "MN" });
            }
            if (!string.IsNullOrEmpty(LN) && LN.Length > 50)
            {
                yield return new ValidationResult("Last Name should be maximum of 50 characters", new[] { "LN" });
            }
        }
    }
}
