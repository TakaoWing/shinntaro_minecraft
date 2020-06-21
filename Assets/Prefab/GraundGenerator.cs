using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundGenerator : MonoBehaviour
{

    public GameObject block;

    public int width;   //横
    public int depth;   //縦


    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < width; x++) 
        {
            for(int z = 0; z < depth; z++)
            {
                GameObject instance = Instantiate(block, this.transform, true);
                instance.transform.localPosition += new Vector3(10f *  x,0.0f,10f* z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
