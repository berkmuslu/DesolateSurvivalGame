
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public Text my_text;
    public GameObject character;

    

    void Start()
    {
        my_text = transform.GetChild(0).GetComponent<Text>();
        character = GameObject.Find("Character");

    }

    public void EatFood()
    {
        if (my_text.text.Contains("Coconut"))
        {

            if (character.GetComponent<lifeBars>().playerHunger + 5 >= 100)
            {
                character.GetComponent<lifeBars>().playerHunger = 100;
            }
            else
            {
                character.GetComponent<lifeBars>().playerHunger += 5;
            }
            
            if (character.GetComponent<lifeBars>().playerThirst + 10 >= 100)
            {
                character.GetComponent<lifeBars>().playerThirst = 100;
            }
            else
            {
                character.GetComponent<lifeBars>().playerThirst += 10;
            }
            
            foreach (var item in character.GetComponent<InventorySystem>().inventory)
            {

                if (item.name == "Coconut")
                {
                    item.amount -= 1;
                }
                
            }
            
            
        }  
        
    }
}
