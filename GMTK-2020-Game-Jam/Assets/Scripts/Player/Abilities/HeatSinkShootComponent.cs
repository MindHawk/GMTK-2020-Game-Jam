using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSinkShootComponent : ShootComponent
{
    [Header("Heat Modifiers")]
    [SerializeField]
    private float heatSinkCapacity;
    private float baseHeatCapacity;
    [SerializeField]
    private float heatCapacityPenalty;
    [Header("Visuals")]
    [SerializeField]
    private List<GameObject> VisualIndicators;
    [SerializeField]
    private List<SpriteRenderer> VisualIndicatorSprites;
    [SerializeField]
    private Gradient HeatGradient;

    private void Start()
    {
        baseHeatCapacity = player.heatCapacity;
        player.heatCapacity = baseHeatCapacity + heatSinkCapacity;
        Reloaded.AddListener(OnReload);
    }

    private void FixedUpdate()
    {
        SetHeatSinkColour();
    }
    public override void Shoot()
    {
        base.Shoot();
        player.heatCapacity = baseHeatCapacity - heatCapacityPenalty;
        player.SetCurrentHeat(0);
        foreach (GameObject indicator in VisualIndicators)
        {
            indicator.SetActive(false);
        }
    }

    private void OnReload()
    {
        player.heatCapacity = baseHeatCapacity + heatSinkCapacity;
        foreach (GameObject indicator in VisualIndicators)
        {
            indicator.SetActive(true);
        }
    }

    private void SetHeatSinkColour()
    {
        foreach (SpriteRenderer sprite in VisualIndicatorSprites)
        {
            sprite.color = HeatGradient.Evaluate(player.GetHeatCapacityFraction());
        }
    }
}
