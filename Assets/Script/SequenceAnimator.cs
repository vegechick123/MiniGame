using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceAnimator : MonoBehaviour
{
    public float WaitBetween = 0.15f;
    public float WaitEnd = 0.5f;
    List<Animator> _animators;
    

    void Start()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        StartCoroutine(DoAnimation());
        
    }
    IEnumerator DoAnimation()
    {
        while (true)
        {
            foreach(var animator in _animators)
            {
                Debug.Log("animate");
                animator.SetTrigger("DoSlidingUp");
                yield return new WaitForSeconds(WaitBetween);

            }
            yield return new WaitForSeconds(WaitEnd);
        }
        
    }
   
  
}
