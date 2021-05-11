using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FinalCutsceneTrigger : MonoBehaviour
{
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private PlayableDirector badCutscene;
    [SerializeField] private PlayableDirector goodCutscene;
    private bool wasTriggered = false;
    [SerializeField] private AudioSource negativeSound;
    [SerializeField] private AudioSource positiveSound;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by " + other.gameObject.tag);

        if (!wasTriggered)
        {
            if (other.gameObject.CompareTag(enemyTag))
            {
                Play(negativeSound, badCutscene);
            }
            else if (other.gameObject.CompareTag(playerTag))
            {
                Play(positiveSound, goodCutscene);
            }
        }
    }

    IEnumerator StartTrigger(AudioSource au, PlayableDirector dir) 
    {
        if (au != null)
        {
            au.Play();
            yield return new WaitForSecondsRealtime(0.01f);
        }
        dir.Play();
        wasTriggered = true;
    }

    private Coroutine Play(AudioSource au, PlayableDirector dir) => StartCoroutine(StartTrigger(au, dir));
}
