using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaTest : MonoBehaviour {


    public float angle = 60;    // 角度
    public float power = 15;    // 力度
    public float flySpeed = 2; // 飞行速度
    public float resistance = -5;    // 阻力
    public float gravity = -9.81f;  // 重力


    private Vector3 startSpeed;   // 初速度向量
    private Vector3 gravitySpeed = Vector3.zero;    // 重力速度向量
    private float flyTimer;   // 飞行时间
    private Vector3 prevPosition;


    // Use this for initialization
    void Start ()
    {
        startSpeed = Quaternion.Euler(new Vector3(-angle, 0, 0)) * Vector3.forward * power;
    }
	

	void FixedUpdate () {

        float flySpeed = Time.fixedDeltaTime * this.flySpeed;

        float resistance = Time.fixedDeltaTime * this.resistance;

        gravitySpeed.y = gravity * (flyTimer += flySpeed);

        if (startSpeed.y + gravitySpeed.y < 0)
        {
            //gravitySpeed.z += resistance;
        }
        gravitySpeed.z += resistance;

        transform.position += (startSpeed + gravitySpeed) * flySpeed;

        if (prevPosition != Vector3.zero && transform.position != prevPosition)
        {
            transform.rotation = Quaternion.FromToRotation(-Vector3.forward, transform.position - prevPosition); //旋转箭头，指向下一个移动的坐标点

        }
        prevPosition = transform.position;
    }
}
