using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour
{
    public List<GameObject> nodepath;
    public GameObject currentnode;
    public GameObject targetnode;
    public float speed;
    public int stopnumber;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = currentnode.transform.position;
        this.stopnumber = 0;
        this.targetnode = nodepath[stopnumber];
    }

    // Update is called once per frame
    void Update()
    {
        if (this.targetnode != null) {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetnode.transform.position, step);
            if (Vector3.Distance(this.transform.position,targetnode.transform.position) <= 0.05) {
                // reached object
                this.transform.position = targetnode.transform.position;
                this.currentnode = targetnode;
                stopnumber += 1;
                this.targetnode = nodepath[stopnumber % nodepath.Count];
                Debug.Log("At target");
            }
        }
    }

}
