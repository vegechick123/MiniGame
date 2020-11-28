using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    //public bool fixCenterOfMass;
    public float rotateSpeed;
    public float moveSpeed;
    public float externForce;
    public float deltaAngle { get { return angle - m_rigidbody2D.rotation; } }//与目标角度的差值
    public float rotateAngle { get { return Mathf.Min(Time.fixedDeltaTime * rotateSpeed, Mathf.Abs(deltaAngle)); } }//当前单位时间内旋转的角度
    Rigidbody2D m_rigidbody2D;

    public float[] verticle;
    public float[] horizon;
    public float[] rotation;
    public int curIndexVertical = 0;
    public int curIndexHorizon = 0;
    public int curIndexRotation = 0;
    public int max = 10;
    public float angle { get { return rotation[curIndexRotation]; } }
    public Vector2 targetPosition { get { 
            return  new Vector2(horizon.Length<=0?m_rigidbody2D.position.x:horizon[curIndexHorizon],
                verticle.Length <= 0 ? m_rigidbody2D.position.y : verticle[curIndexVertical]); } }


    public AudioClip lightOn;

    private AudioSource music;
    private void Awake()
    {
        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        m_rigidbody2D = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        music.clip = lightOn;
        music.Play();
        music.loop = true;
    }
    void Refresh(int targetIndex)
    {
        if (0 <= targetIndex && targetIndex < position.Length)
        {
            transform.localPosition= position[targetIndex];
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, rotation[targetIndex]));
            curIndex = targetIndex;
        }
    }
    public void ChangeHorizon(int chageValue)
    {
        int targetIndex = Mathf.Clamp(curIndexVertical + chageValue, 0, horizon.Length-1);
        curIndexVertical = targetIndex;
    }
    public void ChangeVerticle(int chageValue)
    {
        int targetIndex = Mathf.Clamp(curIndexVertical + chageValue, 0, verticle.Length-1);
        curIndexVertical = targetIndex;
    }
    public void ChangeRotation(int chageValue)
    {
        int targetIndex = Mathf.Clamp(curIndexRotation + chageValue, 0, rotation.Length-1);
        curIndexRotation = targetIndex;
    }
    private void FixedUpdate()
    {
        float curAngle = Mathf.Sign(deltaAngle) * rotateAngle + m_rigidbody2D.rotation;
        Vector2 curPosition = Vector2.MoveTowards(m_rigidbody2D.position, targetPosition,moveSpeed*Time.fixedDeltaTime);
        m_rigidbody2D.MoveRotation(curAngle);
        m_rigidbody2D.MovePosition(curPosition);
    }
}
