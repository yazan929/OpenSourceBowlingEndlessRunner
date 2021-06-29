using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModeer : MonoBehaviour
{
    public Vector3 offset;
    public List<GameObject> prefabs = new List<GameObject>();
    public GameObject currentLand;
    public int startTileIndex = 1;
    public int maxRepeat = 3;
    List<int> previousIndexes = new List<int>();
    public float landLength;
    bool canSpawn = true;
    public static MapModeer Instance;
    void Awake() => Instance = this;

    void Start(){

        SpawnTile(false);
    }

    void Update()
    {

        Vector3 playerPos = Player.Instance.transform.position + offset;
        float distanceToCurrentLand = playerPos.z - currentLand.transform.position.z;

        if (canSpawn && Mathf.Abs(distanceToCurrentLand) > 10)
        {

            SpawnTile();
        }

        else
        {

            canSpawn = true;
        }
    }

    void SpawnTile(bool useRandom = true)
    {
        int index = useRandom ? Random.Range(0, prefabs.Count) : startTileIndex;

        canSpawn = false;
        Vector3 newPos = currentLand.transform.position + (Player.Instance.transform.forward.normalized * landLength);

        if (previousIndexes.Count >= maxRepeat)
        {

            if (index == previousIndexes[previousIndexes.Count - 1] && index == previousIndexes[previousIndexes.Count - 2])
            {
                index = GetNextIndex(index);
                previousIndexes.RemoveAt(0);
            }
        }

        if (useRandom) previousIndexes.Add(index);
        currentLand = Instantiate(prefabs[index], newPos, Quaternion.identity);

        Destroy(currentLand, 20);
    }

    int GetNextIndex(int num)
    {

        if (num == prefabs.Count - 1)
        {
            return 0;
        }

        return num + 1;
    }
}