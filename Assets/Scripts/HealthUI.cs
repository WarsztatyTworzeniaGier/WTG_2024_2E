using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private Image hearthPrefab;

    [SerializeField]
    private Transform heartsContainter;

    private List<Image> hearts = new();

    [ContextMenu(nameof(TestHearts))]
    private void TestHearts()
    {
        SetHearts(3);
    }

    public void SetHearts(int count)
    {
        for(int i = 0; i < count; i++)
        {
            var newHeart = Instantiate(hearthPrefab, heartsContainter);
            hearts.Add(newHeart);
        }

        SetHealth(count);
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }

    public void RemoveHearth()
    {
        if(hearts.Count == 0) 
        { 
            return; 
        }

        Destroy(hearts[0].gameObject);
        hearts.RemoveAt(0);

        healthSlider.value = hearts.Count;
    }
}
