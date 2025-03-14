using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeshTrail : MonoBehaviour
{

		public float activeTime = 2f;

		public float meshRefreshRate = 0.1f;
		public float meshDestroyDelay = 3f;
		public Transform positionToSpawn;

		public Material mat;
		public string shaderVarRef;
		public float shaderVarRate = 0.1f;
		public float shaderVarRefreshRate = 0.05f;

		private bool isTrailActive;
		private SkinnedMeshRenderer[] skinnedMeshRenderers;
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey (KeyCode.E) && Input.GetKey (KeyCode.Q)  && !isTrailActive)
			{
				
			}
    }

	public void Start_Trail()
    {
        if (!isTrailActive)
        {
			isTrailActive = true;
			StartCoroutine(ActiveTrail(activeTime));
		}
	}

	IEnumerator ActiveTrail(float timeActive)
		{
			while(timeActive > 0)
			{
				timeActive -= meshRefreshRate;
				
				if(skinnedMeshRenderers == null) 
					skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
				
				for(int i=0; i<skinnedMeshRenderers.Length; i++)
				{
					GameObject gObj = new GameObject();
					gObj.transform.SetPositionAndRotation(positionToSpawn.position, positionToSpawn.rotation);

					MeshRenderer mr = gObj.AddComponent<MeshRenderer>();
					MeshFilter mf = gObj.AddComponent<MeshFilter>();
					
					Mesh mesh = new Mesh();
					skinnedMeshRenderers[i].BakeMesh(mesh);
					
					mf.mesh = mesh;
					mr.material = mat;

					StartCoroutine(AnimateMaterialFloat(mr.material, 0, shaderVarRate, shaderVarRefreshRate));
					
					Destroy(gObj, meshDestroyDelay);
				}
				
				yield return new WaitForSeconds(meshRefreshRate);
			}
			
			isTrailActive = false;
	
		}

	IEnumerator AnimateMaterialFloat(Material mat, float goal, float rate, float refreshRate)
	{
		float valueToAnimate = mat.GetFloat(shaderVarRef);
		while (valueToAnimate > goal)
		{
			valueToAnimate -= rate;
			mat.SetFloat(shaderVarRef, valueToAnimate);
			yield return new WaitForSeconds(refreshRate);
		}
	}
}
