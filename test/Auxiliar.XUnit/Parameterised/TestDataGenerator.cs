using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Auxiliar.XUnit.Parameterised
{
    public static class TestDataGenerator 
    {
        public static IEnumerable<object[]> GetNumbersFromDataGenerator()
        {
            yield return new object[] { 5, 1, 3, 9 };
            yield return new object[] { 7, 1, 5, 3 };
        }

        public static IEnumerable<object[]> GetPersonFromDataGenerator()
        {
            yield return new object[]
            {
            new Person {Name = "Tribbiani", Age = 56},
            new Person {Name = "Gotti", Age = 16},
            new Person {Name = "Sopranos", Age = 15},
            new Person {Name = "Corleone", Age = 27}
            };

            yield return new object[]
            {
            new Person {Name = "Mancini", Age = 79},
            new Person {Name = "Vivaldi", Age = 16},
            new Person {Name = "Serpico", Age = 19},
            new Person {Name = "Salieri", Age = 20}
            };
        }    
    }
}
