using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237hashtable
{
    class GenericHashMap<TKey,TValue>
    {
        //Declare a constant for the prime value to use in the hash function.
        private const int PRIMEVALUE=97;

        //Declare an array for the values.
        TValue[] theValues;
        TKey[] theKeys;

        //Constructor
        public GenericHashMap()
        {
            //Instantiate the array
            theValues = new TValue[PRIMEVALUE];
        }
        //Put function to put a key value pair into the array / hash table
        public void Put(TKey key, TValue value)
        {
            //Get the index to put the value into
            int indexForValue = hashFunction(key);

            //Put the key info into the keys array.
            //This part is not needed, but we ar doing it so that we can
            //output the keys when we print the hash table out.
            theKeys[indexForValue] = key;

            //Store the value into the array.
            theValues[indexForValue] = value;
        }
        public override string ToString()
        {
            string returnString = "key   => Value\n";
            returnString += "---------------------\n";
            for(int i=0;i<theValues.Length;i++)
            {
                if(theValues[i] != null)
                {
                    returnString += theKeys[i] + " =>"+theValues[i]+ "\n";
                }
            }
            return returnString;
        }
        public string ShowArrays()
        {
            string returnString = "Idx -Key   => Value\n";
            returnString += "---------------------";
            for (int i = 0; i < theValues.Length; i++)
            {
                returnString += "["+ i + "] - "+ theKeys[i] + " =>" + theValues[i] + "\n";
            }
            return returnString;
        }
        //Get a value out using the passed in key.
        public TValue Get(TKey key)
        {
            //Get the index to put the value into
            int indexForValue = hashFunction(key);

            //Get the value out of the array with the calculated key.
            return theValues[indexForValue];
        }

        //Ye ol hash function
        private int hashFunction(TKey key)
        {
            //Use the built in GetHashCode method that comes from object
            //to get an integer value that can be modded with the primevalue.
            //This will give us an integer between 0 and the PRIMEVALUE.
            return key.GetHashCode() % PRIMEVALUE;
        }
    }
}
