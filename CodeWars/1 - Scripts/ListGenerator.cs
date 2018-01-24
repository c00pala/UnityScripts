using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ListGenerator : MonoBehaviour {

    #region Variables:
    // Reference to DataHolder instance.
    [SerializeField]
    private DataHolder dh;

    // Prefab for text object, to display list on UI.
    [SerializeField]
    private GameObject textPrefab;

    // How many text items / customers will there be in our randomised list.
    // I encourage testers to increase this variable - default 75.
    [SerializeField]
    private int totalTextItemsAtStart;
    private int totalTextItems;

    // This is going to be our final list of Customers that is used to display results.
    private Customer[] displayArray;

    private int loopCounter = 1;
    #endregion

    private void Start()
    {
        totalTextItems = totalTextItemsAtStart;
        // Using a coroutine to give some visual feedback to process.
        StartCoroutine("PerformanceLoop");
    }

    private IEnumerator PerformanceLoop()
    {
        UnityEngine.Debug.Log("Running loop # " + loopCounter + " ---------------->");
        // Loop the main function a few times, outputting the time taken.
        GenerateCustomersAndDisplay(totalTextItems);
        totalTextItems *= 2;
        loopCounter++;

        yield return new WaitForSeconds((totalTextItems * 0.0001f));

        // Prevents totalTextItems exceeding the total customers available.
        if (totalTextItems <= 75)
        {
            StartCoroutine("PerformanceLoop");
        }
    }

    private void GenerateCustomersAndDisplay(int textItems)
    {
        
        UnityEngine.Debug.Log("Generating list of " + textItems + " customers.");
        Stopwatch sw = new Stopwatch();
        // Fun stuff goes here:

        string time = "";

        // Start stopwatch.
        sw.Start();

        GenDisplayArray();

        // Stopwatch result, clear and restart stopwatch after.
        sw.Stop();
        time = sw.Elapsed.TotalMilliseconds.ToString();
        UnityEngine.Debug.Log("Time taken to populate array: " + time + "ms");
        sw.Reset();
        sw.Start();

        CreateText();

        // Second stopwatch result.
        sw.Stop();
        time = sw.Elapsed.TotalMilliseconds.ToString();
        UnityEngine.Debug.Log("Time taken to generate text: " + time + "ms");
    }

    // Function to generate random list of customers.
    private void GenDisplayArray()
    {
        // Initialise / clear display array.
        displayArray = new Customer[totalTextItems];

        // Populate array.
        for (int i = 0; i < totalTextItems; i++)
        {
            // Get random number between 0 and total customers available in DataHolder.
            int rnd = Random.Range(0, dh.customerList.Count);

            // While this number matches an existing customer in display array.
            // Maybe an issue at higher numbers?
            while (CustomerUnique(rnd) == false)
            {
                // Do the random thing again.
                rnd = Random.Range(0, dh.customerList.Count);
            }

            // Assign to the display array once we find a unique customer.
            // Oh boy oh boy, LINQ.
            displayArray[i] = dh.customerList.SingleOrDefault(c => c.accID == rnd);
        }
    }

    // Function to generate the text items in game.
    private void CreateText()
    {
        for (int i = 0; i < totalTextItems; i++)
        {
            // Create, assign parent and enable new text object.
            GameObject newText = Instantiate(textPrefab);
            newText.transform.SetParent(textPrefab.transform.parent, false);
            newText.SetActive(true);

            // Get customer from array, call him Bob.
            // Bob is new, newBob.
            Customer newBob = displayArray[i];

            // Set text.
            string newString = "Customer: " + newBob.name + " - AccID: " + newBob.accID.ToString("0000");
            newText.GetComponent<Text>().text = newString;
        }
    }

    // Function to check the display list and ensure selected customer is unique.
    private bool CustomerUnique(int cID)
    {
        // Create a bool, set to true by default.
        bool isUnique = true;

        // Go through displayArray, ensure no matching items.
        foreach (Customer c in displayArray)
        {
            // Do a little checky check, if not null and has an ID that matches
            // then customer is not unique, set to false.
            if (c != null && c.accID == cID) isUnique = false;
        }

        // Return result.
        return isUnique;
    }

}
