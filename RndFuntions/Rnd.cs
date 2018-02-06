/*
 * Author: c00pala
 * Jan - 2018 - v2
 * Randomise Functions.
 * Add 'using TCScript' to your scripts
 * and access via: Rnd.function();
 */

namespace TCScript
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Rnd : MonoBehaviour
    {
        #region Random Chance Functions:
        
        /*
         * Function to return a true / false result from a check out of 100.
         * Pass it a value between 0 and 100 - e.g. if you'd like a condition 
         * to have a 30% chance of returning true, you would do:
         * if (Chance100(30) == true);
         * Check passed = true. Check failed = false.
         */

        public static bool Chance100(float percentChance)
        {
            percentChance = Mathf.Round(percentChance);

            bool passed = false;

            if (Random.Range(0, 101) <= percentChance)
            {
                passed = true;
            }

            return passed;
        }
        #endregion

        #region Generate List Functions:

        /* 
         * Function to generate a list of random Integers.
         * First two parameters are required (minValue and maxValue, the last two are optional).
         */

        public static List<int> RndIntList(int minValue, int maxValue, int listSize = 10, bool noDuplicates = true)
        {
            // Temp list to return results.
            List<int> returnList = new List<int>();

            // If duplicates elements are to be removed.
            if (noDuplicates == true)
            {
                // Adjust list to prevent potential inf loop.
                if (listSize > (maxValue - minValue))
                {
                    Debug.Log("RndList - RndIntList Error - Too few possible values for given list size. Size of return list has been decreased to prevent infinite loop.");
                    listSize = (maxValue - minValue);
                }

                // Breakpoint values.
                int breakCounter = 0;
                int breakPoint = listSize * 1000;

                // Loop to populate temp list, list should grow to be correct size.
                while (returnList.Count < listSize)
                {
                    // Breakpoint check.
                    breakCounter++;
                    if (breakCounter > breakPoint)
                    {
                        Debug.Log("RndList - RndIntList Error - breakpoint hit. Check given values.");
                        return null;
                    }

                    // Get new random int using parameters.
                    int rnd = Random.Range(minValue, maxValue + 1);

                    // If value does not exist in temp list, add it.
                    if (!returnList.Contains(rnd))
                    {
                        returnList.Add(rnd);
                    }
                    // Else, do nothing, continue loop.
                }
            }

            // Return temp list.
            return returnList;
        }
        #endregion

        #region Randomise Existing List Function:
        /* 
         * Function to randomise a provided List. Returns a list of the values in random order.
         * removeDuplicates does as it says, it will ensure duplicate values are removed from return list.
         * nonRepeating is optional, if duplicates are removed it's not possible to get repeating values,
         * by default, non repeating is true, you only need to provide it if you want it to be false and get 
         * a pure, randomised return List - i.e. ALL values you give it, in random order, with repeating allowed.
         */

        public static List<T> RandomiseList<T>(List<T> list, bool removeDuplicates, bool nonRepeating = true)
        {
            /* Create two lists of generic type 'T' to work with during function.
             * newList will be our return list, initalise this as a new, empty list.
             * tempList is a new instance of a List, populated with the contents of the parameter 'list'.
             * Notice we do NOT do 'tempList = list', doing this means that tempList is the same instance as the variable being provided
             * - e.g. if we remove a value from tempList, it will be removed from the List being used as the parameter too
             * So, in my example above, this means it would also remove the item from 'vList' or 'sList'.
             * If unsure, test it to see how it behaves, change tempList to: List<T> tempList = list;
             */

            List<T> newList = new List<T>();
            List<T> tempList = new List<T>(list);

            // Initiate a loop, create a temp int to use as loop count.
            // We don't use tempList.Count in the loop condition as it will change during the loop.
            int totalCount = tempList.Count;

            int breakCounter = 0;
            int breakPoint = (tempList.Count * 1000);

            for (int i = 0; i < totalCount; i++)
            {
                // Breakpoint - ensure we never get stuck in an infinite loop.
                breakCounter++;
                if (breakCounter > breakPoint)
                {
                    Debug.Log("RndList - RandomiseList Error - Breakpoint hit. Possibly too few elements in list to find non-repeating, or all elements left in list are the same value.");
                    return null;
                }

                // Do NOT remove duplicates:
                if (removeDuplicates == false)
                {
                    // Create a temp random int, use tempList.Count to ensure we're always getting a value in range.
                    int rnd = Random.Range(0, tempList.Count);
                    // Create temp generic variable to hold result.
                    var value = tempList[rnd];

                    // If this is the first run in the loop, or if nonRepeating is false, no need to worry about repeating.
                    if (nonRepeating == false || i == 0)
                    {
                        // Add to newList, remove from tempList.
                        newList.Add(value);
                        tempList.Remove(value);
                    }
                    // If the last element in newList does not equal our current random value.
                    else if (!newList[newList.Count - 1].Equals(value))
                    {
                        // Add to newList, remove from tempList.
                        newList.Add(value);
                        tempList.Remove(value);
                    }
                    // Else, the last element in newList does equal our current random value, therefore will repeat.
                    else
                    {
                        // Ignore any changes to lists, decrease i by 1 to ensure loop will repeat.
                        i--;
                    }
                }
                // DO remove duplicates:
                else
                {
                    // As above, pick a random value from tempList.
                    int rnd = Random.Range(0, tempList.Count);
                    var value = tempList[rnd];

                    // If newList does NOT already have an instance of value.
                    if (newList.Contains(value) == false)
                    {
                        // Add to newList, remove from tempList.
                        newList.Add(value);
                        tempList.Remove(value);
                    }
                    else
                    {
                        // Ignore adding to newList and remove from tempList.
                        tempList.Remove(tempList[rnd]);
                    }
                }
            }

            // Return final contents of newList.
            return newList;
        }
        #endregion

        #region String Generator Functions:
        #endregion
    }
}