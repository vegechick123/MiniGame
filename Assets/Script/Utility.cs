using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class Utility
{

    public static Vector3 Vec2ToVec3(this Vector2 target)
    {
        return new Vector3(target.x, target.y);
    }
    public static void InvokeAfter(this MonoBehaviour target, Action task, float time)
    {
        target.StartCoroutine(InvokeAfter(task, time));
    }
    public static IEnumerator InvokeAfter(Action task, float time)
    {
        yield return new WaitForSeconds(time);
        task();

    }
    public static void InvokeNextFrame(this MonoBehaviour target, Action task)
    {
        target.StartCoroutine(InvokeNextFrame(task));
    }
    public static IEnumerator InvokeNextFrame(Action task)
    {
        yield return null;
        task();

    }
    public static void InvokeNextFixedFrame(this MonoBehaviour target, Action task)
    {
        target.StartCoroutine(InvokeNextFixedFrame(task));
    }
    public static IEnumerator InvokeNextFixedFrame(Action task)
    {
        yield return new WaitForFixedUpdate();
        task();

    }
}
