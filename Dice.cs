using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    public InputManager _inputManager;

    [SerializeField]
    private Rigidbody RB;

    public int spinFactor;
    public float raydebugdist;
    public GameObject[] numbers;
    public int force;

    private float xRS, yRS, zRS;
    private int numberInt;
    private Transform originSpawn;

    public enum diceState {thrown, falling, landed};
    private diceState thisState;

	void Start () {
        RB = this.GetComponentInChildren<Rigidbody>();
        originSpawn = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

        switch (thisState)
        {
            case (diceState.landed):
                xRS = 0; yRS = 0;zRS = 0;
                if (Input.GetKeyDown(KeyCode.J))
                {
                    ThrowUp();
                    xRS = Random.Range(0f, 1f) * spinFactor;
                    yRS = Random.Range(0f, 1f) * spinFactor;
                    zRS = Random.Range(0f, 1f) * spinFactor;
                    //Debug.Log("RotxSpd: " + xRS.ToString() + "  RotySpd: " + yRS + "  RotzSpd: " + zRS.ToString());
                }
                if (_inputManager.OneFinger())
                {
                    Tapped();
                    xRS = Random.Range(0f, 1f) * spinFactor;
                    yRS = Random.Range(0f, 1f) * spinFactor;
                    zRS = Random.Range(0f, 1f) * spinFactor;
                    //Debug.Log("RotxSpd: " + xRS.ToString() + "  RotySpd: " + yRS + "  RotzSpd: " + zRS.ToString());
                }
                Debug.Log("Dice: landed");
                break;
            case (diceState.falling):
                SpinMeRound(xRS, yRS, zRS);
                Debug.Log("Dice: falling");
                break;
            case (diceState.thrown):
                SpinMeRound(xRS, yRS, zRS);
                if (RB.velocity.y <= 0)
                {
                    thisState = diceState.falling;
                }
                Debug.Log("Dice: thrown");
                break;
            default:
                if (RB.velocity.y <= 0)
                {
                    thisState = diceState.falling;
                }
                Debug.Log("No diceState");
                break;
        }

        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, Vector3.up * raydebugdist);
        Debug.DrawRay(ray.origin, ray.direction * raydebugdist, Color.black);
        if(Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            string number = hit.collider.name;
            print(number);
            numberInt = WhatDiceNumber(number);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (thisState == diceState.falling)
        {
            if (collision.gameObject.transform.position.y <= this.transform.position.y)
            {
                Debug.Log(collision.gameObject.tag);
                thisState = diceState.landed;
            }
        } 
    }

    public int GetDiceNumber()
    {
        return numberInt;
    }

    public void ResetPos()
    {
        this.transform.TransformDirection(originSpawn.rotation.eulerAngles);
        this.transform.TransformPoint(originSpawn.position);
        
    }

    public void ThrowUp()
    {
        RB.AddForce(Vector3.up * force);
        thisState = diceState.thrown;
    }

    private void Tapped()
    {
        Touch zero = _inputManager.touchZero;
        RaycastHit hit2;
        Ray ray2 = Camera.main.ScreenPointToRay(zero.position);
        Debug.DrawRay(ray2.origin, ray2.direction, Color.green);
        if (Physics.Raycast(ray2.origin, ray2.direction, out hit2))
        {
            if (hit2.collider.tag == "Dice")
            {
                ThrowUp();
            }
        }
    }

    private void SpinMeRound(float xRS,float yRS,float zRS)
    {
        this.transform.Rotate(xRS * Time.deltaTime, yRS * Time.deltaTime, zRS * Time.deltaTime);
        Debug.Log("Dice = spinning");
    }

    public diceState GetState()
    {
        return thisState;
    }
    public int WhatDiceNumber(string check)
    {
        switch (check)
        {
            case "1":
                return 1;
            case "2":
                return 2;
            case "3":
                return 3;
            case "4":
                return 4;
            case "5":
                return 5;
            case "6":
                return 6;
            default:
                return 0;
        }
    }
}
