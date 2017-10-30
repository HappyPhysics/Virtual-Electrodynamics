using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeElectricField : MonoBehaviour {
    [SerializeField] private float m_charge = 1.0f;

    [SerializeField] GameObject arrow;
    // Use this for initialization

    public float charge 
        {
        get {return m_charge;}
        }
	void Start ()
    {
        for (int arrIndx = 1; arrIndx < 100; arrIndx++)
        {
            makeArrow();
        }

    }

    private void makeArrow()
    {
        Vector3 arrowPosition = transform.position + UnityEngine.Random.insideUnitSphere * 3.0f;
        if ((arrowPosition - transform.position).sqrMagnitude > 1)
        {
            GameObject newArrow = Instantiate(arrow);
            Vector3 electricField = getElectricField(arrowPosition);
            newArrow.transform.position = arrowPosition;
            newArrow.transform.localScale = 100 * electricField.magnitude * Vector3.one;
            newArrow.transform.forward = electricField;
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

   // returns the electric 
   private Vector3 getElectricField(Vector3 position)
    {
        Vector3 electricField = m_charge * (position - transform.position) / Mathf.Pow((position - transform.position).magnitude, 3.0f);
        return electricField;
    }
}
