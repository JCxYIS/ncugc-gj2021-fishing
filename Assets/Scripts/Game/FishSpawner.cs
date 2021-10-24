using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishSpawner : MonoBehaviour
{
    // Queue<Fish> FishList = new Queue<Fish>();
    Transform fishContainer;
    public float spawnXLimit = 5;

    public List<GameObject> spawnedFish = new List<GameObject>();

    public void Respawn()
    {
        if(fishContainer)
        {
            Destroy(fishContainer.gameObject);
            spawnedFish.ForEach(s=>Destroy(s));
            spawnedFish.Clear();
        }        
        fishContainer = new GameObject().transform;
        fishContainer.gameObject.name = "----------Fish Container----------";

        // load fish database
        List<GameObject> fishGoDb = new List<GameObject>(Resources.LoadAll<GameObject>("Fish"));
        List<Fish> fishDb = new List<Fish>();
        fishGoDb.ForEach(f => fishDb.Add(f.GetComponent<Fish>()));

        // determine each fish
        foreach(var fish in fishDb)
        {
            float p = Random.Range(0f, 1f);
            // List<Fish> fishList = new List<Fish>();
            
            // 
            while(p < fish.fishData.Rareness)
            {
                // where to put fish?
                float y = fish.fishData.MinDepth + (fish.fishData.MaxDepth - fish.fishData.MinDepth) * Random.Range(0f, 1f);
                var f = Instantiate(
                    fish.gameObject, 
                    new Vector2(-Random.Range(-Fish.BOUNDRY, Fish.BOUNDRY), -y), 
                    Quaternion.identity);
                f.name = fish.name;
                f.transform.SetParent(fishContainer);
                spawnedFish.Add(f);

                // add
                p += 1 + Random.Range(-0.2f, 0.2f);
            }
        }
    }

    //--
}