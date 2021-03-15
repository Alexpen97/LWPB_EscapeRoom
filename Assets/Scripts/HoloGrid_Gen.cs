using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloGrid_Gen : MonoBehaviour
{
    public float size;
    public float spacing;
    public Material Material;
    public float IdleAnimationtime;

    public float AnimationHeight;
    public float AnimationSpeed;

    private float timer;
    private Vector3 Gridsize;
    public List<GameObject> Rows;
    private float CurrentAnimTime;


    // Start is called before the first frame update
    void Start()
    {
        Gridsize = gameObject.GetComponent<Collider>().bounds.size;
        float timer = IdleAnimationtime;
        Generate();
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0){
            Animate();
            timer = IdleAnimationtime;
        }
        
    }
    private void Generate()
    {
     for( float z = 0; z < Gridsize.z; z ++){
            z = z - 1;
            z = z + size;
            z = z + spacing;

            GameObject row = new GameObject();
            row.transform.parent = gameObject.transform;
            row.transform.localPosition = new Vector3(0, 0, 0);
            Rows.Add(row);
            for (float x = 0; x < Gridsize.x; x++)
            {
                x = x - 1;
                x = x + size;
                x = x + spacing;

                float y = 0.2f;
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale = new Vector3(size,y,size);
                cube.transform.parent = row.transform;
                
                
                cube.transform.localPosition = new Vector3(x, 0, z);
                cube.GetComponent<MeshRenderer>().material = Material;
                


            }
        }

    }
    public void Animate()
    {


            int x = 0;
            CurrentAnimTime = 0;

            bool heightReached = false;
            Vector3 Origin = Rows[x].transform.position;
            Vector3 Destination = new Vector3(Origin.x, Origin.y + AnimationHeight, Origin.z);
            while (!heightReached) { 
            CurrentAnimTime = +Time.deltaTime;
            transform.localPosition = Vector3.Lerp(Origin, Destination, CurrentAnimTime / AnimationSpeed);
                if (Vector3.Distance(transform.localPosition, Destination) < 0)
                {
                x ++;
                CurrentAnimTime = 0;
                 heightReached = false;
                 Origin = Rows[x].transform.position;
                 Destination = new Vector3(Origin.x, Origin.y + AnimationHeight, Origin.z);
            }
               
          }

        
    }
}
