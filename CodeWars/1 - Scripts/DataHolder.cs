using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour {

    #region Main Customer List:
    /* List to hold a heap of Customers, we'll use this to generate another, randomised list of customers.
    / I'm going to pretend this is actually a database, as we shouldn't require write access to achieve our
    / goals, let's impose a rule that we're only allowed to read from it.  */

    public List<Customer> customerList = new List<Customer>();
    #endregion

    private void Awake()
    {
        int counter = 0;
        // Here we simply fille the Customer List, to give us some basic data to play with.
        // I'm giving it 9999 items, just cause why not.
        for (int i = 0; i < 9999; i++)
        {
            // Generate a random name.
            string newName = fNames[Random.Range(0, fNames.Length)] + " " + lNames[Random.Range(0, lNames.Length)];

            // Create new customer object, store in list.
            // Use counter to assign a unique ID to the instance.
            Customer newCust = new Customer(newName, counter);
            customerList.Add(newCust);

            // Inc counter each loop.
            counter++;
        }
    }

    #region Name Arrays:
    private string[] fNames = new string[] { "Nikole", "Gudrun", "Justine", "Raleigh", "Keven", "Loni", "Vicky", "Michiko", "Lita", "Charlie", "Felton", "Quentin", "Lamont", "Marlon", "Collette", "Garnet", "Cortez", "Domitila", "Audra", "Winifred", "Marcene", "Stacie", "Valentine", "Gilberto", "Lou", "Lucio", "Janina", "Jeniffer", "Alonso", "Bob", "Annie", "Joselyn", "Wilton", "Lila", "Stepanie", "Cordia", "Wendi", "Eve", "Nia", "Ellis", "Inez", "Josphine", "Carlee", "Refugia", "Lucien", "Cristy", "Cuc", "Loria", "Lessie", "Geoffrey", "Alleen","Agueda","Erminia","Miriam","Nickie","Charisse","Denna","Galen","Malissa","Jeremy","Katherin","Olympia","Vanna","Dennise","Ann","Rosanne","Tammara","Sharita","Mandi","Winfred","Desmond","Lucio","Georgiann","Georgann","Sung","Berneice","Bernardo","Shela","Zack","Karoline","Ethyl","Hwa","Arianne","Sharri","Jaimee","Zachary","Wonda","Leonore","Arron","Tiny","Ladonna","Dannie","Angelika","Seema","Marian","Kassandra","Dante","Marcelina","Delaine","Eldon"};

    private string[] lNames = new string[] { "Krause", "Ellis", "Short", "Salazar", "Douglas", "Costa", "Baxter", "Cummings", "Cooley", "Alexander", "Gonzalez", "Webster", "Joyce", "Mccoy", "Abbott", "Ballard", "Durham", "Parrish", "Pittman", "Chaney", "Sutton", "Juarez", "Huff", "Ward", "Cooper", "Bullock", "Glass", "Shields", "Paul", "Bradley", "Blackburn", "Beltran", "Logan", "Castillo", "Keller", "Sampson", "Dunlap", "Bolton", "Moon", "Macdonald", "Casey", "Phillips", "Chase", "Dawson", "Owen", "Strong", "Hardin", "Marquez", "Davidson", "Walton", "Welch", "Oneill", "Levy", "Cameron", "Garza", "Yoder", "Randolph", "Evans", "Meadows", "Romero", "Boyle", "Chambers", "Horton", "Potts", "Hooper", "Reid", "Pham", "Swanson", "Le", "Beasley", "Blackwell", "Beck", "Matthews", "Torres", "Wood", "Carter", "Montes", "Ramos", "Atkins", "Richard", "Berg", "Savage", "Knight", "Mcbride", "Lamb", "Wilcox", "Armstrong", "Ray", "Booker", "Dunn", "Ali", "Mcdaniel", "Valenzuela", "Neal", "Rios", "Jordan", "Hess", "Hanson", "Wyatt", "Walters" };
    #endregion
}

public class Customer
{
    public string name;
    public int accID;

    public Customer(string n, int id)
    {
        name = n;
        accID = id;
    }
}
