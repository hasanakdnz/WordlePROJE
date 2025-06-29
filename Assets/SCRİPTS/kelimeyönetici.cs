
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class WordManager : MonoBehaviour
{
   
    [SerializeField]
    private List<string> wordList;

   
    private string currentWord;

    
    private void Awake()
    {
        
        SelectRandomWord();
    }

    
    private void SelectRandomWord()
    {
       
        if (wordList == null || wordList.Count == 0)
        {
            Debug.LogError("Word List'e hiç kelime eklenmemiş! Lütfen WordManager nesnesini kontrol edin.");
            
            currentWord = ""; 
            return;
        }

        int randomIndex = Random.Range(0, wordList.Count);

        currentWord = wordList[randomIndex].ToUpper(); 

        
        Debug.Log($"Bu tur için doğru kelime: {currentWord}");
    }

    
    public List<State> GetStates(string msg)
    {
        var result = new List<State>();

        var list = currentWord.ToCharArray().ToList();
        var listCurrent = msg.ToUpper().ToCharArray().ToList();

        
        for (var i = 0; i < listCurrent.Count; i++)
        {
            var currentChar = listCurrent[i]; 
            
            
            var contains = list.Contains(currentChar);

            if (contains)
            {
                
                var isCorrect = list[i] == currentChar;
                if (isCorrect)
                {
                    
                    result.Add(State.Correct); 
                }
                else
                {
                    
                    result.Add(State.Contain);
                }
            }
            else
            {
                
                result.Add(State.Fail);
            }
        }
        
        return result;
    }
}