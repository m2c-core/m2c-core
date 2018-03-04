using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Content.Model
{
    public static class Validator
    {
        private static Dictionary<Type, Func<object, bool>> validators = new Dictionary<Type, Func<object, bool>>()
        {
            { typeof(ContentItem),ValidateContentItem},
        };

        public static bool Validate<T>(T model)
        {
            bool b = false;
            if (validators.ContainsKey(model.GetType()))
            {
                b = validators[model.GetType()](model);
            }
            return b;
        }

        private static bool ValidateContentItem(object model)
        {
            bool b = true;

            return b;
        }



    }
}
