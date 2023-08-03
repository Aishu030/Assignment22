using System;
using System.Reflection;
//Reflection Assignment

namespace Assignment22
{
    public class Program
    {
        public static void MapProperties(Source source, Destination destination)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                PropertyInfo matchingDestinationProperty = Array.Find(destinationProperties, dp => dp.Name == sourceProperty.Name);

                if (matchingDestinationProperty != null && matchingDestinationProperty.PropertyType == sourceProperty.PropertyType)
                {
                    matchingDestinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }
        }
         public static void Main(string[] args)
         {
            Source source = new Source
            {
                Id = 03,
                Name= "Aishu",
                Age=22
            };

            Destination destination = new Destination()
            {
                Salary = 300000
            };

            MapProperties(source, destination);
            Console.WriteLine("Id: " + destination.Id);
            Console.WriteLine("Name: " + destination.Name);
            Console.WriteLine("Address: " + destination.Age);
            Console.WriteLine("Salary: "+ destination.Salary);
            Console.WriteLine("Press Any key to continue.......");
            Console.ReadKey();
         }
    }
}

