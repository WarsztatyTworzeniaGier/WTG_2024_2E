using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;

    public int damage = 100;

    [SerializeField]
    private float moveSpeed = 1f;

    private bool isAlive = true;

    private bool isMovine = false;

    private string enemyName = "Goliat";


    // Start is called before the first frame update
    void Start()
    {
        if (isAlive) //jeśli warunek to prawda
        {
            //kod tutaj sie wykona    
        }
        else if(health > 0)
        {
        }
        else
        {
            
            Debug.Log("cos");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack()
    {

    }
}
