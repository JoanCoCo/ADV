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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by " + other.gameObject.tag);

        if (!wasTriggered)
        {
            if (other.gameObject.CompareTag(enemyTag))
            {
                badCutscene.Play();
                wasTriggered = true;
            }
            else if (other.gameObject.CompareTag(playerTag))
            {
                goodCutscene.Play();
                wasTriggered = true;
            }
        }
    }
}
