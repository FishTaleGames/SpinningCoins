using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayCoins : MonoBehaviour, IPointerClickHandler
{
    public ParticleSystem coins;

    [Header("Ratio of Screen Width Radius")]
    public float coinScale;


    private void Start()
    {
        SetCoinsEmitterSize();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayCoinsEmitter();
    }


    private void SetCoinsEmitterSize()
    {
        float screenWidth = transform.parent.GetComponent<RectTransform>().rect.width;
        float newCoinScale = screenWidth * coinScale;
        coins.GetComponent<RectTransform>().localScale = new Vector3(newCoinScale, newCoinScale, newCoinScale);
        
        ParticleSystem.ShapeModule coinShape = coins.shape;
        coinShape.radius = (screenWidth / newCoinScale) / 2;
    }

    private void PlayCoinsEmitter()
    {
        if (!coins.isPlaying)
            coins.Play();
    }
}
