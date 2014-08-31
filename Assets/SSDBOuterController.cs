using UnityEngine;
using System.Collections;

public class SSDBOuterController : MonoBehaviour {

	public GameObject[] particle_lines;

	private System.Random r;
	private int[] particle_status = new int[6];
	private int particle_interval = 0;

	// Use this for initialization
	void Start () {

		r = new System.Random(1000);

		for(int i = 0; i < particle_lines.Length; i++){
			particle_lines[i].particleSystem.Pause();
		}

	}
	
	// Update is called once per frame
	void Update () {

		if(particle_interval < 180){
			gameObject.transform.Rotate (new Vector3((float)r.Next (2, 8), (float)r.Next (2, 8), (float)r.Next(2,8)));
			particle_interval++;
		}
		else{
			// 一旦すべて表示状態にする
			for(int i = 0; i < particle_status.Length; i++){
				particle_lines[i].particleSystem.renderer.enabled = true;
				particle_status[i] = 0;
			}

			int counter = 0;

			// ランダムで1/3を選んで消す
			while(counter < (particle_lines.Length / 3)){
				int index = r.Next(0, particle_lines.Length - 1);
				if(particle_status[index] == 0){
					particle_status[index] = 1;
					particle_lines[index].renderer.enabled = false;
					counter++;
					//Debug.Log (index);
				}
			}
			particle_interval = 0;
		}
	}
}
