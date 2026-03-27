using UnityEngine;
using static UnityEditor.PlayerSettings;

public class LevelManager : MonoBehaviour
{
    public GameObject[] brickPrefabs;
    public Transform parent;

    //public int rows = 5; //จำนวนแถว
    //public int cols = 8; // จำนวนบล็อก
    public float spacing = 1.2f; // itptsjk'its;jk'[]Hvd
    public float startZ = 0f; // เริ่มในการสร้างบล็อก
    public int brickCount;

    void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {

        int rows = Random.Range(5, 10 + 1);
        int cols = Random.Range(5, 10 + 1);
        
        float offsetX = (cols - 1) * spacing / 2;
        float offsetZ = (rows - 1) * spacing / 2;

        brickCount = 0;


        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 pos = new Vector3(
                    x * spacing - offsetX,
                    0,
                    startZ + y * spacing 
                );



                GameObject brick = Instantiate(
                        brickPrefabs[Random.Range(0, brickPrefabs.Length)],
                        pos,
                        Quaternion.identity,
                        parent
                    );

                    brickCount++;
                }
            }
        }
    public void BrickDestroyed()
    {
        brickCount--;

        if (brickCount <= 0)
        {
            GenerateLevel();
        }
    }
}



