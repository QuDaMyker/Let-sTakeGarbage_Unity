using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnGarbage: MonoBehaviour
{
    public List<Sprite> ImagesOrganic;
    public List<Sprite> ImagesInorganic;
    public List<GarbageController> Garbages;

    void Start()
    {
        AssignSprites();
    }
    void AssignSprites()
    {
        foreach (GarbageController garbage in Garbages)
        {
            garbage.ImagesOrganic = ImagesOrganic;
            garbage.ImagesInorganic = ImagesInorganic;
        }
    }
    /*
    private static IList<T> Shuffle<T>(IList<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        IList<T> result = new List<T>(list);
        int n = result.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = result[k];
            result[k] = result[n];
            result[n] = value;
        }
        return result;
    }*/
}
