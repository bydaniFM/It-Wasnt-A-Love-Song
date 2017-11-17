using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour {

    //public SpriteRenderer sprite;
    public GameObject myParticle;
    public ParticleSystemRenderer pr;

    public float alpha = 1;
    //public Material myMaterial;

    //public Color spriteColor = Color.white;
    //public float fadeInTime = 1.5f;
    //public float fadeOutTime = 3f;
    //public float delayToFadeOut = 5f;
    //public float delayToFadeIn = 5f;
    //private float knobValue;

    void Start()
    {
        pr = myParticle.GetComponent<ParticleSystemRenderer>();
        //myMaterial = myParticle
        //StartCoroutine("FadeCycle");
    }

    public void glitchFade(float knobValue)
    {
        alpha = knobValue;
        pr.renderMode = ParticleSystemRenderMode.VerticalBillboard;
        pr.material.color = (new Color(1f, 1f, 1f, knobValue));


        //Debug.Log("Glitch fade, alpha value" + myParticle.GetComponent<Material>().color.a);
        ////sprite.color.a = knobValue;
        ////float alpha = knobValue;
        ////sprite.color = (new Color(1f, 1f, 1f, knobValue));
        //myParticle.GetComponent<Material>().color = (new Color(1f, 1f, 1f, knobValue));
    }

    //public void glitchFader(float knobValue)
    //{
    //    float fade = 0;
    //    float startTime = 0;

    //    while (true)
    //    {
    //        startTime = Time.time;
    //        while (fade < 1f)
    //        {
    //            fade = Mathf.Lerp(0f, 1f, (Time.time - startTime) / fadeInTime);
    //            spriteColor.a = fade;
    //            sprite.color = spriteColor;
    //            //yield return null;
    //        }
    //        //Make sure it's set to exactly 1f
    //        fade = 1f;
    //        spriteColor.a = fade;
    //        sprite.color = spriteColor;
    //        //yield return new WaitForSeconds(delayToFadeOut);

    //        startTime = Time.time;
    //        while (fade > 0f)
    //        {
    //            fade = Mathf.Lerp(1f, 0f, (Time.time - startTime) / fadeOutTime);
    //            spriteColor.a = fade;
    //            sprite.color = spriteColor;
    //            //yield return null;
    //        }
    //        fade = 0f;
    //        spriteColor.a = fade;
    //        sprite.color = spriteColor;
    //        //yield return new WaitForSeconds(delayToFadeIn);
    //    }
    //}
}