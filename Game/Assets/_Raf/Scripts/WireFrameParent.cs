using UnityEngine;
using System.Collections;

public class WireFrameParent : MonoBehaviour {
	private WireFrameChild[] wireFrameChild;
	private Transform c_playerTransform;
	private Transform c_transform;
	private float distance=0;
	public float maxDistance=3;
	public float roughness = 30f;
	public float thickness = 0.04f;
	
	void Start () {
		wireFrameChild=GetComponentsInChildren<WireFrameChild>();
		c_playerTransform=GameObject.FindGameObjectWithTag("Player").transform;
		c_transform=transform;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		//if(Physics.Raycast(c_transform.position, c_playerTransform.position-c_transform.position,out hit,100.0f)){
			//if(hit.transform.tag=="Player"){
				distance=Vector3.Distance(transform.position,c_playerTransform.position);
				if(distance<=maxDistance){
					for(int i=0 ; i<wireFrameChild.Length ; i++){
						wireFrameChild[i].SetTextureScale(roughness*Random.value*10);
						wireFrameChild[i].SetThickness(thickness*((maxDistance-distance)/maxDistance));
					}
				}
			//}else{
				//for(int i=0 ; i<wireFrameChild.Length ; i++){
					//wireFrameChild[i].SetTextureScale(roughness*Random.value*10);
					//wireFrameChild[i].SetThickness(0);
				//}
			//}
		//}else{
			//for(int i=0 ; i<wireFrameChild.Length ; i++){
				//wireFrameChild[i].SetTextureScale(roughness*Random.value*10);
				//wireFrameChild[i].SetThickness(0);
			//}
		//}
	}
}