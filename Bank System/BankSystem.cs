using System;
using System.Collections.Generic;

namespace BankSystem
{
    // Class that manages the overall bank system operations
    public class BankSystem
    {
        // List to hold all persons in the bank system
        private List<Person> persons;

        // Constructor to initialize the bank system with an empty list of persons
        public BankSystem()
        {
            persons = new List<Person>();
        }

        // Method to create a new person in the bank system
        public void RegisterPerson(string name)
        {
            Person newPerson = new Person(name);
            persons.Add(newPerson);
            Console.WriteLine($"{name} has been registered successfully.");
        }

        // Method to get a person by their name
        public Person GetPersonByName(string name)
        {
            foreach (var person in persons)
            {
                if (person.Name == name)
                {
                    return person;
                }
            }
            return null; // If person is not found
        }

        // Method to display all registered persons
        public void DisplayRegisteredPersons()
        {
            Console.WriteLine("\nRegistered Persons:");
            foreach (var person in persons)
            {
                Console.WriteLine($"- {person.Name}");
            }
        }
    }
}
