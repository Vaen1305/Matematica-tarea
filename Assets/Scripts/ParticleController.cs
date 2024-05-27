using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public Material material;
    public int emissionRate;
    public float startSpeed;
    public float startSize;

    private void Start()
    {
        ConfigureParticleSystem();
    }

    private void ConfigureParticleSystem()
    {
        ParticleSystem.MainModule main = particleSystem.main;
        main.startSpeed = startSpeed;
        main.startSize = startSize;

        ParticleSystem.EmissionModule emission = particleSystem.emission;
        emission.rateOverTime = emissionRate;

        ParticleSystemRenderer renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        renderer.material = material;
    }
}
