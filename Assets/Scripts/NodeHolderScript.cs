using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeHolderScript : MonoBehaviour
{
    public GameObject wireobject;
    
    [ContextMenu("Do things")]
    public void setUpNodes() {
        Debug.Log("Setting up nodes");
    }

    void Start() {
        Debug.Log("Setting up nodes");
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node")) {
            foreach (GameObject adjacentnode in node.GetComponent<NodeScript>().adjacentnodes) {
                Debug.Log("Making wires");
                //Vector3 centerPos = (node.transform.position + adjacentnode.transform.position)  / 2f;
                float size = Vector3.Distance(node.transform.position, adjacentnode.transform.position);
                Vector3 dir = adjacentnode.transform.position - transform.position;
                Debug.Log("Making wires");
                GameObject wire = Instantiate(wireobject);
                wire.transform.position = node.transform.position;
                wire.transform.localScale = new Vector3(1, 1, size/2);
                wire.transform.LookAt(adjacentnode.transform.position);
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node")) {
            foreach (GameObject adjacentnode in node.GetComponent<NodeScript>().adjacentnodes) {
                Gizmos.DrawLine(node.transform.position, adjacentnode.transform.position);
            }
        }
    }
    
}
