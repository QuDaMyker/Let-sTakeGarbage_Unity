using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarbageController : MonoBehaviour
{
    public int Type;
    //public Image Image;
    public float Speed;
    public float Amplitude;
    public float topSpawn;
    public float bottomSpawn;
    public float bgWidth;
    public List<Sprite> ImagesOrganic;
    public List<Sprite> ImagesInorganic;
    private bool isDrag;
    private GameObject obj;
    private float timeAppear;
    private float alpha;
    private Vector2 Direct;
    //private 
    private void Spawn()
    {
        SpriteRenderer sprrdr = obj.GetComponent<SpriteRenderer>();
        Type = Random.Range(0, 2);
        if (Type == 0)
        {
            sprrdr.sprite = ImagesOrganic[Random.Range(0, ImagesOrganic.Count - 1)];
        }
        else
        {
            sprrdr.sprite = ImagesInorganic[Random.Range(0, ImagesInorganic.Count - 1)];

        }

        timeAppear = Random.Range(0, CONS.TimeGarbageAppearMax);
        if (Random.Range(0, 2) == 0)
        {
            Debug.Log("to the right");
            //từ trái
            Direct = new Vector2( 1, 0);
            obj.transform.position = new Vector3(- bgWidth / 2, Random.Range(topSpawn, bottomSpawn), 0);
        }
        else
        {
            Debug.Log("to the left");
            //từ phải
            Direct = new Vector2(- 1, 0);
            obj.transform.position = new Vector3(bgWidth / 2, Random.Range(topSpawn, bottomSpawn), 0);
        }

        obj.transform.Rotate(0, 0, Random.Range(0, 360));
        //obj.transform.rotation = new Quaternion(0, 0, Random.Range(0, 180), 0);
            //new Vector3(0, 0, Random.Range(0, 360));
    }
    // Start is called before the first frame update

    void Start()
    {
        obj = gameObject;
        //obj.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        Amplitude = CONS.Amplitude;
        Speed = CONS.Speed;
        isDrag = false;
        alpha = 0;
        Spawn();
    }

    private void Move()
    {   
        if (timeAppear < 0)
        {
            float x = obj.transform.position.x + Direct.x * Speed;
            float y = obj.transform.position.y + Direct.y * Speed + Amplitude * Mathf.Sin(alpha);
            alpha = (alpha < Mathf.PI * 2 ? alpha + CONS.SpeedWaving : 0);
            obj.transform.position = new Vector3( x, y, 0);
        }
        else
        {
            timeAppear -= Time.deltaTime;
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.Timeout == 0) return;
        if (! isDrag)
        {
            if (obj.transform.position.x <= bgWidth / 2 && obj.transform.position.x >= - bgWidth / 2) //CARE
            {
                Move();
            }
            else
            {
                Spawn();
            }
        }
    }
    public void OnMouseDrag()
    {
        //Debug.Log("dr");
        isDrag = true;
        obj.transform.position = GetMousePos();
    }
    Vector3 GetMousePos()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
    private void OnMouseUp()
    {
        isDrag = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (! isDrag)
        {
            if (collision.gameObject.CompareTag("InorganicTrashBin") || collision.gameObject.CompareTag("OrganicTrashBin"))
            {
                if (collision.gameObject.CompareTag("OrganicTrashBin") && Type == (int)CONS.EType.ORGANIC) 
                {
                    GameController.instance.GainScore();
                }
                else if (collision.gameObject.CompareTag("InorganicTrashBin") && Type == (int)CONS.EType.INORGANIC)
                {
                    GameController.instance.GainScore();
                }
                else
                {
                    Debug.Log(0);
                }

                Spawn();
            
                //enabled = false;
            }
        }
    }
}
