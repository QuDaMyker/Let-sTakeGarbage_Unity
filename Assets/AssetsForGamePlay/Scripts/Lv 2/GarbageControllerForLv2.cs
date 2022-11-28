using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarbageControllerForLv2 : MonoBehaviour
{
    public int Type;
    //public Image Image;
    public float Speed;
    public float Acceleration;
    public float Friction;
    public float topSpawn;
    public float bottomSpawn;
    public float bgWidth;
    public List<Sprite> ImagesOrganic;
    public List<Sprite> ImagesInorganic;
    public GameObject checkEffect;
    public Sprite xIcon;
    private bool isDrag;
    private GameObject obj;
    //private float timeAppear;
    private float alpha;
    //private Vector2 Direct;
    //private 
    float time = 0;
    private void FirstSpawn()
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

        obj.transform.position = new Vector3( Random.Range(- bgWidth / 2, bgWidth / 2), Random.Range(topSpawn, bottomSpawn), 0);
        /*timeAppear = Random.Range(0, CONS.TimeGarbageAppearMax);
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
        }*/

        obj.transform.Rotate(0, 0, Random.Range(0, 360));
        //obj.transform.rotation = new Quaternion(0, 0, Random.Range(0, 180), 0);
            //new Vector3(0, 0, Random.Range(0, 360));
    }
    // Start is called before the first frame update

    void Start()
    {
        obj = gameObject;
        //obj.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        //Amplitude = CONS.Amplitude;
        Speed = 0;
        isDrag = false;
        Friction = CONS.Friction;
        alpha = 0;
        FirstSpawn();
    }

    private void MoveAndRoll()
    {
        /*if (timeAppear < 0)
        {
            float x = obj.transform.position.x + Direct.x * Speed;
            float y = obj.transform.position.y + Direct.y * Speed + Amplitude * Mathf.Sin(alpha);
            alpha = (alpha < Mathf.PI * 2 ? alpha + CONS.SpeedWaving : 0);
            obj.transform.position = new Vector3( x, y, 0);
        }
        else
        {
            timeAppear -= Time.deltaTime;
        }*/
        if (Speed > 0)
        {
            float x = obj.transform.position.x + Speed;
            float y = obj.transform.position.y;
            Speed -= Friction;
            //alpha = (alpha < Mathf.PI * 2 ? alpha + CONS.SpeedWaving : 0);

            obj.transform.position = new Vector3(x, y, 0);
            obj.transform.Rotate(0, 0, Speed * CONS.SpeedRolling);
        }
    }
    private void NextSpawn()
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

        obj.transform.position = new Vector3(- bgWidth / 2, Random.Range(topSpawn, bottomSpawn), 0);
        /*timeAppear = Random.Range(0, CONS.TimeGarbageAppearMax);
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
        }*/

        obj.transform.Rotate(0, 0, Random.Range(0, 360));
        //obj.transform.rotation = new Quaternion(0, 0, Random.Range(0, 180), 0);
        //new Vector3(0, 0, Random.Range(0, 360));
    }
    // Update is called once per frame
    void Update()
    {
        if (time > CONS.TimeFrame)
        {
            if (GameController.instance.Timeout == 0) return;
            if (!isDrag)
            {
                if (obj.transform.position.x <= bgWidth / 2 && obj.transform.position.x >= -bgWidth / 2) //CARE
                {
                    MoveAndRoll();
                }
                else
                {
                    NextSpawn();
                }
            }
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
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
                    AddCheckEffect(collision.transform, true);
                    GameController.instance.GainScore();
                }
                else if (collision.gameObject.CompareTag("InorganicTrashBin") && Type == (int)CONS.EType.INORGANIC)
                {
                    AddCheckEffect(collision.transform, true);
                    GameController.instance.GainScore();
                }
                else
                {
                    AddCheckEffect(collision.transform, false);
                    Debug.Log(0);
                }

                //Spawn();
                //obj.SetActive(false);
                //enabled = false;
                NextSpawn();
            }
        }
    }
    public void BeFlown()
    {
        Speed = CONS.WindSpeed;
        Debug.Log(Speed);
    }
    void AddCheckEffect(Transform pos, bool iswrong)
    {
        GameObject obj = Instantiate(checkEffect, pos);
        obj.transform.position = new Vector3(6.2f, 3.1f, 0);
        if (!iswrong) obj.gameObject.GetComponent<SpriteRenderer>().sprite = xIcon;
        Destroy(obj, 1);
    }
}
