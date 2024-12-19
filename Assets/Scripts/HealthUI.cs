using DG.Tweening;
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

    [SerializeField]
    private Ease sliderEase;

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
        healthSlider.maxValue = health;
    }

    public void RemoveHeart()
    {
        if(hearts.Count == 0) 
        { 
            return; 
        }

        Destroy(hearts[0].gameObject);
        hearts.RemoveAt(0);

        healthSlider.DOValue(hearts.Count, 0.3f).SetUpdate(true).SetEase(sliderEase);
    }
}
