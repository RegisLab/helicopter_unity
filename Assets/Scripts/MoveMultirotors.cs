using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using SimpleSharpResiver;

public class MoveMultirotors : MonoBehaviour
{
	[SerializeField] public GameObject quadrotor; //The Cube
	// private SimBridge simBridge;

	private SimLinkManager _simLinkManager;

	private GameObject[] _arrQuadrotor;
	private int _numObjects = 0;
	// private float count = 0;
	private bool _initSpwanFlag = false;

	private float _x = 0;
	private float _y = 0;
	private float _z = 0;

	void Start()
	{

		_simLinkManager = SimLinkManager.Instance;
		// mainApp.simBridge;
		// mainApp.simBridge = new SimBridge("127.0.0.1", 34674, 34675);
		// mainApp.simBridge.startBridge();

		_numObjects = _simLinkManager.GetModelCount();

		if (_numObjects != 0)
			SpawnVehicle(_numObjects);
	
		// for (int i = 0; numObjects == 0; i++)
		// {
		// 	numObjects = simBridge.modelCount;
		// }
		// if (numObjects != 0)
		// {
		// 	arrQuadrotor = new GameObject[numObjects];
		// }
		// for (int i = 0; i < numObjects; i++)
		// {
		// 	arrQuadrotor[i] = Instantiate(quadrotor, new Vector3((float)i, 0, 0), Quaternion.identity) as GameObject;
		// }
	}

	public void SpawnVehicle(int modelCount)
	{
		_arrQuadrotor = new GameObject[modelCount];
		for (int i = 0; i < modelCount; i++)
		{
			_arrQuadrotor[i] = Instantiate(quadrotor, new Vector3((float)i, 0, 0), Quaternion.identity) as GameObject;
		}
		_initSpwanFlag = true;
	}

	void Update()
	{
		// // for (int i = 0; numObjects == 0; i++)
		// {
		// 	numObjects = simLinkManager_.GetModelCount();
		// }
		// Debug.Log("numObjects: "+ numObjects.ToString());
		// if (numObjects != 0	&& flag == true)
		// {
		// 	arrQuadrotor = new GameObject[numObjects];
		// 	for (int i = 0; i < numObjects; i++)
		// 	{
		// 		arrQuadrotor[i] = Instantiate(quadrotor, new Vector3((float)i, 0, 0), Quaternion.identity) as GameObject;
		// 	}
		// 	flag = false;
		// }
		// count += 0.1f;
		// if (flag == false)


		// if (numObjects != 0)
		if (_initSpwanFlag)
		{
			for (int i = 0; i < _numObjects; i++)
			{
				if(_simLinkManager.CheckModelStatus(i) == true)
				{

					_x = (float)_simLinkManager.GetModelStateVecComponent(i, 0);
					_y = (float)_simLinkManager.GetModelStateVecComponent(i, 2);
					_z = (float)_simLinkManager.GetModelStateVecComponent(i, 1);
					// x_ = (float)simLinkManager_.simBridge.modelsStates[i].state[0];
					// y_ = (float)simLinkManager_.simBridge.modelsStates[i].state[2];
					// z_ = (float)simLinkManager_.simBridge.modelsStates[i].state[1];
					
					_arrQuadrotor[i].transform.position = new Vector3(_x, _y, _z);
				}
			}
		}
	}
}
