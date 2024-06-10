using CandidateTesting.LeonardoDalben.Formatter.Domain.Enums;

namespace CandidateTesting.LeonardoDalben.Formatter.Domain.Extension
{
    public static class ObjectExtension
    {

        public static object GetValueByPropertyField(this object obj, Field field) 
        {
            var type = obj?.GetType();
            var prop = type?.GetProperty(field.ToString());
            var val = prop?.GetValue(obj, null) ?? null;
            return val;
        }
    }
}
