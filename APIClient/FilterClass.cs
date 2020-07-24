using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APIClient
{
    public class FilterClass
    {
        public string Term { get; set; }
        public int? Limit { get; set; }

        public string GenerateQueryString()
        {
            string queryString = string.Empty;

            PropertyInfo[] propertyInfos = GetProperties(); //Get all public properties

            // write property names
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object value = propertyInfo.GetValue(this, null);
                if (value != null)
                    queryString += string.Format("{0}={1}&", propertyInfo.Name.ToLower(), Convert.ToString(value).ToLower());
            }

            if (queryString.Length > 0)
                queryString = queryString.Substring(0, queryString.Length - 1);

            return queryString;
        }

        //Returns all public properties of an instances of this class
        private PropertyInfo[] GetProperties()
        {
            PropertyInfo[] propertyInfos;
            Type type = this.GetType();
            propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // sort properties by name
            Array.Sort(propertyInfos,
                    delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                    { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });
            return propertyInfos;
        }
    }
}
