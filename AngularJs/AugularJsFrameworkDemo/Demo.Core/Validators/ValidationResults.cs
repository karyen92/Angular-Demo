using System.Collections.Generic;

namespace Demo.Core.Validators
{

    public class ValidationResults
    {
        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();

        public Dictionary<string, string> Errors()
        {
            return errors;
        }

        public void AddError(string key, string value)
        {
            if (errors.ContainsKey(key))
            {
                var temp = errors[key];
                var current = temp + " " + value;
                errors[key] = current;
            }
            else
            {
                errors.Add(key, value);
            }
        }
    }
}
