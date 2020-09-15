using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSinkShootComponent : ShootComponent
{
    [SerializeField]
    private float heatSinkCapacity;
    private float baseHeatCapacity;
    [SerializeField]
    private List<GameObject> VisualIndicators;
    private void Start()
    {
        baseHeatCapacity = player.heatCapacity;
        player.heatCapacity = baseHeatCapacity + heatSinkCapacity;
        Reloaded.AddListener(OnReload);
    }
    public override void Shoot()
    {
        base.Shoot();
        player.heatCapacity = baseHeatCapacity;
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
}
