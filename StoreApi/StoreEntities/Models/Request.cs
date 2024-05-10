using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Request
    {
        private List<ValidationResult> results { get; set; }
        private ValidationContext context { get { return new ValidationContext(this, null, null); } }

        public bool ModelIsValid()
        {
            results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(this, context, results, true))
            {
                return false;
            }

            return true;
        }

        public string[] GetErrors()
        {
            List<string> errors = new List<string>();

            if (results != null && results.Count > 0)
            {
                foreach (var error in results)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            return errors.ToArray();
        }
    }
}
