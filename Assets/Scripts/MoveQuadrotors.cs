using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleSharpResiver;

public class MoveQuadrotors : MonoBehaviour
{
	[SerializeField] public GameObject quadrotor; //The Cube
	private SimBridge simBridge = new SimBridge("127.0.0.1", 34674, 34675);

	private GameObject[] arrQuadrotor;
	private int numObjects = 0;
	private float count = 0;
	private bool flag = true;

	private float x_ = 0;
	private float y_ = 0;
	private float z_ = 0;

	void Start()
	{
		simBridge.startBridge();

		numObjects = simBridge.modelCount;;
	
		// for (int i = 0; numObjects == 0; i++)
		// {
		// 	numObjects = simBridge.modelCount;
		// }
		if (numObjects != 0)
		{
			arrQuadrotor = new GameObject[numObjects];
		}
		for (int i = 0; i < numObjects; i++)
		{
			arrQuadrotor[i] = Instantiate(quadrotor, new Vector3((float)i, 0, 0), Quaternion.identity) as GameObject;

		}
	}

	void Update()
	{
		// for (int i = 0; numObjects == 0; i++)
		{
			numObjects = simBridge.modelCount;
		}
		Debug.Log("numObjects: "+ simBridge.modelCount.ToString());
		if (numObjects != 0	&& flag == true)
		{
			arrQuadrotor = new GameObject[numObjects];
			for (int i = 0; i < numObjects; i++)
			{
				arrQuadrotor[i] = Instantiate(quadrotor, new Vector3((float)i, 0, 0), Quaternion.identity) as GameObject;
			}
			flag = false;
		}
		count += 0.1f;
		if (flag == false)
		if (simBridge.modelCount != 0)
			for (int i = 0; i < numObjects; i++)
			{
				if(simBridge.modelsStates[i].status == true)
				{

					x_ = (float)simBridge.modelsStates[i].state[0];
					y_ = (float)simBridge.modelsStates[i].state[2];
					z_ = (float)simBridge.modelsStates[i].state[1];
					
					arrQuadrotor[i].transform.position = new Vector3(x_, y_, z_);
				}
			}
	}
}
