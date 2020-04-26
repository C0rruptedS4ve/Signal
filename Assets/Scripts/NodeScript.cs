using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public GameObject north;
    public GameObject east;
    public GameObject south;
    public GameObject west;
    public Material linematerial;
    public List<GameObject> adjacentnodes;
    
    void Awake() {
        adjacentnodes = new List<GameObject>();
        if (north != null) {adjacentnodes.Add(north);}
        if (east != null) {adjacentnodes.Add(east);}
        if (south != null) {adjacentnodes.Add(south);}
        if (west != null) {adjacentnodes.Add(west);}
    }
    // Start is called before the first frame update
    void Start()
    {
        

        // foreach (GameObject adjacentnode in adjacentnodes) {
        //     if (adjacentnode != null) {
        //         // Add a Line Renderer to the GameObject
        //         LineRenderer line = this.gameObject.AddComponent<LineRenderer>();
        //         line.material = linematerial;
        //         line.startWidth = 0.5f;
        //         line.endWidth = 0.5f;
        //         line.positionCount = 2;
        //         line.SetPosition(0, this.transform.position);
        //         line.SetPosition(1, adjacentnode.transform.position);
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
