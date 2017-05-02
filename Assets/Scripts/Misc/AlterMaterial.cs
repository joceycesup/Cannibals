﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterMaterial : MonoBehaviour {

	public Terrain terrain;
	private List<Vector4> agents = new List<Vector4>();
    public List<GameObject> agentGO= new List<GameObject>();

    public float effectArea = 0;
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < agentGO.Count; ++i)
        {
            while (i >= agents.Count)
                agents.Add(Vector3.zero);
            Vector3 pos = agentGO[i].transform.position;
            agents[i] = new Vector4(pos.x, pos.y, pos.z, 1);
        }
        MaterialPropertyBlock mp = new MaterialPropertyBlock();
        if(agents.Count > 0)
            mp.SetVectorArray("_AgentPositions", agents);
        mp.SetFloat("_AgentAmount", agents.Count);
        mp.SetFloat("_SizeEffect", effectArea);
        terrain.SetSplatMaterialPropertyBlock(mp);
    }
}
