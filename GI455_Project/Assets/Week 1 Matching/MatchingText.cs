using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingText : MonoBehaviour
{

    public Text inputWord;
    public Text result;

    string[] itemlists =  { "Sword", "Claymore", "Bow", "Polearm", "Catalyst", "Paimon" };
        

    public void CheckToItemlist(string word)
    {

        word = inputWord.text;
        print(word);

        for(int i = 0; i <= itemlists.Length; i++)
        {
            if (itemlists[i] == word)
            {
                result.color = Color.green;
                result.text = "[ " + word + " ] is found";                              
                break;
            }

            for (int j = 0; j <= itemlists.Length; j++)
            {

                if (itemlists[j] != word)
                {
                    result.color = Color.red;
                    result.text = "[ " + word + " ] is not found";
                    break;
                }

            }
        }      
        
        
    }
    
}
