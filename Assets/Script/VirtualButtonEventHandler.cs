using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler {

	// Private fields to store the models
	private GameObject Turbina;
	private GameObject Drone;
	private GameObject Robo;
	private GameObject btn_1;
	private GameObject btn_2;
	private GameObject btn_3;

	/// Called when the scene is loaded
	void Start() {

		// Search for all Children from this ImageTarget with type VirtualButtonBehaviour
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < vbs.Length; ++i) {
			// Register with the virtual buttons TrackableBehaviour
			vbs[i].RegisterEventHandler(this);
		}

		// Find the models based on the names in the Hierarchy
		Turbina = transform.Find("turbinas").gameObject;
		Drone = transform.Find("_drone_animado").gameObject;
		Robo = transform.Find("_robot").gameObject;

		btn_1 = transform.Find("fx1").gameObject;
		btn_2 = transform.Find("fx2").gameObject;
		btn_3 = transform.Find("fx3").gameObject;
		// We don't want to show Jin during the startup
		Turbina.SetActive(false);
		Drone.SetActive(false);
		Robo.SetActive (false);
		btn_1.SetActive(true);
		btn_2.SetActive(true);
		btn_3.SetActive (true);
	}

	/// <summary>
	/// Called when the virtual button has just been pressed:
	/// </summary>
	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		//Debug.Log(vb.VirtualButtonName);
		Debug.Log("Button pressed!");

		switch(vb.VirtualButtonName) {
		case "btnLeft":
			btn_1.SetActive(false);
			btn_2.SetActive(true);
			btn_3.SetActive (true);
			Turbina.SetActive(false);
			Drone.SetActive(false);
			Robo.SetActive (true);
			break;
		case "btnRight":
			btn_1.SetActive(true);
			btn_2.SetActive(true);
			btn_3.SetActive (false);
			Turbina.SetActive(true);
			Drone.SetActive(false);
			Robo.SetActive (false);
			break;

		case "btnCenter":
			btn_1.SetActive(true);
			btn_2.SetActive(false);
			btn_3.SetActive (true);
			Turbina.SetActive(false);
			Drone.SetActive(true);
			Robo.SetActive (false);
			break;
			//   default:
			//       throw new UnityException("Button not supported: " + vb.VirtualButtonName);
			//           break;
		}

	}

	/// Called when the virtual button has just been released:
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) { 
		Debug.Log("Button released!");
	}
}