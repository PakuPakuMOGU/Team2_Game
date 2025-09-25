using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Portal_Controller : MonoBehaviour
{
    //assigned in Inspector
    [Header("Applied to the effects at start")]
    [SerializeField] private Color portalEffectColor;

    [Header("Changing these might `break` the effects")]
    [Space(20)]
    [SerializeField] private Renderer portalRenderer;
    [SerializeField] private ParticleSystem[] effectsParticles;
    [SerializeField] private Light portalLight;

    private float maxIntPortalLight = 4;
    private float transitionSpeed = 0.3f;

    //assigned when Awake
    private bool inTransition, activated;
    private Material portalMat, portalEffectMat;
    private float fadeFloat;

    private Coroutine transitionCor;

    private void Awake()
    {
        Setup();
    }

    //Call this function to activate or deactivate the effects
    public void TogglePortal(bool _activate)
    {
        if (inTransition || _activate == activated)
            return;
    
        if (_activate)//toggle on
        {
            activated = true;

            transitionCor = StartCoroutine(PreActivate());
        }
        else if (!_activate)//toggle off
        {
            activated = false;

            effectsParticles[2].Stop();

            transitionCor = StartCoroutine(TransitionSequence());
        }
    }

    private IEnumerator PreActivate()
    {
        inTransition = true;
        effectsParticles[0].Play();

        yield return new WaitForSeconds(2.2f);

        yield return new WaitForSeconds(0.3f);

        transitionCor = StartCoroutine(TransitionSequence());
        effectsParticles[2].Play();
    }

    private IEnumerator TransitionSequence()
    {
        inTransition = true;

        while (inTransition)
        {
            if (activated)//transition to on
            {
                fadeFloat = Mathf.MoveTowards(fadeFloat, 1f, Time.deltaTime * transitionSpeed);

                if (fadeFloat >= 1f)//transition finished
                {
                    inTransition = false;
                }
            }
            else //transition to off
            {
                fadeFloat = Mathf.MoveTowards(fadeFloat, 0f, Time.deltaTime * transitionSpeed);

                if (fadeFloat <= 0f)//transition finished
                {
                    inTransition = false;
                    effectsParticles[2].Stop();
                }
            }
    
            //fade in/out
            portalEffectMat.SetFloat("_PortalFade", fadeFloat);
            portalMat.SetFloat("_EmissionStrength", fadeFloat);

            portalLight.intensity = maxIntPortalLight * fadeFloat; 
    
            yield return null;
        }
    }

    private void Setup()
    {
        //Getting/creating material instance
        Material[] mats = portalRenderer.materials.ToArray();
        portalMat = mats[0];
        portalEffectMat = mats[1];

        //Deactivate effects on Start
        portalMat.SetColor("_EmissionColor", portalEffectColor);
        portalMat.SetFloat("_EmissionStrength", 0);
        portalEffectMat.SetColor("_ColorMain", portalEffectColor);
        portalEffectMat.SetFloat("_PortalFade", 0f);

        foreach (ParticleSystem part in effectsParticles)
        {
            ParticleSystem.MainModule mod = part.main;
            mod.startColor = portalEffectColor;
        }
        portalLight.intensity = 0f;
    }
}
