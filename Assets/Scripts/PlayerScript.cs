using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool atnode;
    public GameObject currentnode;
    public GameObject targetnode;
    public float speed;
    public GameObject startnode;

    // Start is called before the first frame update
    void Start()
    {
        GoToStart();
    }

    void GoToStart() {
        this.transform.position = startnode.transform.position;
        this.currentnode = startnode;
        this.targetnode = null;
        this.atnode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.targetnode != null) {
            float step =  speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetnode.transform.position, step);
            if (Vector3.Distance(this.transform.position,targetnode.transform.position) <= 0.05) {
                // reached object
                this.transform.position = targetnode.transform.position;
                this.currentnode = targetnode;
                this.targetnode = null;
                this.atnode = true;
                Debug.Log("At target");
            }
        }
        float westeast = Input.GetAxis("Horizontal");
        float northsouth = Input.GetAxis("Vertical");
        if (this.atnode) {
            if (westeast > 0) {
                this.MoveTowards(this.currentnode.GetComponent<NodeScript>().east);
            }
            else if (westeast < 0) {
                this.MoveTowards(this.currentnode.GetComponent<NodeScript>().west);
            }
            else if (northsouth > 0) {
                this.MoveTowards(this.currentnode.GetComponent<NodeScript>().north);
            }
            else if (northsouth < 0) {
                this.MoveTowards(this.currentnode.GetComponent<NodeScript>().south);
            }
        }
        else {
            if (westeast > 0 && targetnode.GetComponent<NodeScript>().east == this.currentnode) {
                GameObject other = this.targetnode;
                this.MoveTowards(this.currentnode);
                this.currentnode = other;
            }
            if (westeast < 0 && targetnode.GetComponent<NodeScript>().west == this.currentnode) {
                GameObject other = this.targetnode;
                this.MoveTowards(this.currentnode);
                this.currentnode = other;
            }
            if (northsouth > 0 && targetnode.GetComponent<NodeScript>().north == this.currentnode) {
                GameObject other = this.targetnode;
                this.MoveTowards(this.currentnode);
                this.currentnode = other;
            }
            if (northsouth < 0 && targetnode.GetComponent<NodeScript>().south == this.currentnode) {
                GameObject other = this.targetnode;
                this.MoveTowards(this.currentnode);
                this.currentnode = other;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        //GoToStart();
        if (other.tag == "Respawn") {
            GoToStart();
        }
    }

    private void MoveTowards(GameObject target) {
        if (target != null) {
            this.atnode = false;
            this.targetnode = target;
        }

    }

}
