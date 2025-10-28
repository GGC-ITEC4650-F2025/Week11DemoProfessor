using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class DieController : MonoBehaviour
{
    Rigidbody myBod;
    public float rollForce;

    public string currentValue;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 f = new Vector3(
                Random.Range(-1f, 1f), 5, Random.Range(-1f, 1f));

            Vector3 p = transform.position - new Vector3(
                Random.Range(-1f, 1f), -0.5f, Random.Range(-1f, 1f));

            myBod.AddForceAtPosition(f * rollForce, p, ForceMode.Impulse);
        }

        //check all children

        //find the index of the one with the highest position.y
        int best_i = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Transform bestChild = transform.GetChild(best_i);
            if (child.position.y > bestChild.position.y)
            {
                best_i = i;
            }
        }
        //set the currentValue to the highest child's name
        currentValue = transform.GetChild(best_i).name;
    }
}
