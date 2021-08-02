using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLL.Common
{
    public static class Mapper
    {
        public static object MapObjects(object obj1, object obj2)
        {
            var obj1Properties = obj1.GetType().GetProperties();
            for (int i = 0; i < obj1Properties.Length; i++)
            {
                var obj1PropName = obj1.GetType().GetProperties()[i].Name;
                var obj2Prop = obj2.GetType().GetProperty(obj1PropName);
                if (obj2Prop != null)
                {
                    var obj1PropValue = obj1Properties[i].GetValue(obj1);
                    obj2Prop.SetValue(obj2, obj1PropValue);
                }
            }
            return obj2;
        }

        
    }
}
