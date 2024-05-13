using System.Reflection;

namespace BlogApi.MappingService
{
    public static class Mapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            var destination = Activator.CreateInstance<TDestination>();
            foreach (var sourceProperty in typeof(TSource).GetProperties())
            {
                var destinationProperty = typeof(TDestination).GetProperty(sourceProperty.Name);
                if (destinationProperty != null)
                {
                    if (typeof(TDestination).IsValueType)
                    {
                      destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                      
                    }
                    else
                    {
                        var sourceValue = sourceProperty.GetValue(source);
                        if (sourceProperty != null)
                        {
                            //var propertyRef = Map<TSource, TDestination>(sourceValue);
                            //TDestination propertyRef = Map<sourceProperty.PropertyType, destinationProperty.PropertyType>(sourceProperty.GetValue(source));
                            //destinationProperty.SetValue(destination, propertyRef);
                        }
                    }
        
                }
            }
            return destination;
        }

        
    }
}
