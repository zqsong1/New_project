using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterDestory : MonoBehaviour
{
    public List<GameObject> destoryedgameobject;
    public int destoryedgameobjectnum = 0;
    public GameObject obj_Player;
    private float MoveSpeed = 5f;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (destoryedgameobjectnum != 0)
            {
                Debug.Log(obj_Player.transform.position);
                Vector3 objpos = new Vector3(obj_Player.transform.position.x,
                    obj_Player.transform.position.y, obj_Player.transform.position.z+1.4f);
                GameObject obj = destoryedgameobject[destoryedgameobject.Count - 1];
                Move  m = obj.GetComponent<Move>();
                m.ismove = true;
                //m.StartMove(v,1.3f);
                destoryedgameobject.RemoveAt(destoryedgameobject.Count - 1);
                destoryedgameobjectnum -= 1;
                obj.transform.position = objpos;
            }

            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetMouseButton(0) && other.gameObject.CompareTag("CanDestoryGameobject"))
        {
            Vector3 newpos = new Vector3(obj_Player.transform.position.x,
                obj_Player.transform.position.y - 100, obj_Player.transform.position.z);
            other.gameObject.transform.position = newpos;
            destoryedgameobject.Add(other.gameObject);
            destoryedgameobjectnum += 1;
        }

        if (other.gameObject.CompareTag("door"))
        {
            Animation ani = other.GetComponent<Animation>();
            ani.Play();
            var obj = Resources.Load("Cube");
            GameObject instance = Instantiate(obj) as GameObject;
            Vector3 objpos = new Vector3(0.76f,
                -3.11f, -3.8f);
            instance.transform.position = objpos;
        }
    }
}