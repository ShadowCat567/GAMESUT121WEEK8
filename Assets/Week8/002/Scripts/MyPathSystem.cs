using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyPathSystem : MonoBehaviour 
{
    public enum SeedType { RANDOM, CUSTOM }
    [Header("Random Data")]
    public SeedType seedType = SeedType.RANDOM;

    System.Random random;
    public int seed = 0;

    [Space]
    public bool animatedPath;
    public List<GridCell> gridCellList = new List<GridCell>();
    public int pathLength = 10;

    [Range(1.0f, 22.0f)]
    public float cellSize = 22.0f;

    public GameObject barrierTopPrefab;
    public GameObject barrierRightPrefab;
    public GameObject barrierOpen;
    public GameObject trapSquarePrefab;
    public GameObject chaosGatePrefab;

    public List<GameObject> trapList = new List<GameObject>();
    int maxTraps = 5;

    bool secondPos = false;
    bool endBox = false;
    bool chaosGate = false;

    void SetSeed() 
    {
        if (seedType == SeedType.RANDOM)
            random = new System.Random();
        else if (seedType == SeedType.CUSTOM)
            random = new System.Random(seed);
    }

    private void Start()
    {
        SetSeed();

        if (animatedPath)
        {
            StartCoroutine(CreatePathRoutine());
        }

        else
            CreatePath();
    }

    void CreatePath() 
    {
        gridCellList.Clear();
        Vector2 currentPosition = new Vector2(0f, 0f);
        Vector2 secondPosition = currentPosition;

        gridCellList.Add(new GridCell(currentPosition));

        currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
        float currX = currentPosition.x - cellSize / 2;
        float currxX = currentPosition.x + cellSize / 2;
        float currY = currentPosition.y;
        GameObject startBox = Instantiate(barrierRightPrefab, new Vector3(currX, currY), Quaternion.identity);
        GameObject otherBarrier = Instantiate(barrierOpen, new Vector3(currxX, currY), Quaternion.identity);

        gridCellList.Add(new GridCell(currentPosition));

        for (int i = 0; i < pathLength; i++) 
        {
            int n = random.Next(100);

            if (i == (pathLength - 1))
            {
                currentPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
                endBox = true;
            }

            else
            {
                if (n > 0 && n < 59)
                {
                    currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
                    secondPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
                    secondPos = true;
                }

                else if (n > 60 && n < 79)
                {
                    currentPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
                }

                else
                {
                    currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
                }
            }

            float secX = secondPosition.x + cellSize / 2;
            float secY = secondPosition.y;
            float newX = currentPosition.x + cellSize / 2;
            float newY = currentPosition.y;

            int trapWidth = 3;

            if (n > 0 && n < 19)               
            {
                int trapX = (int)currentPosition.x - (int)cellSize / 2 + trapWidth;
                int trap1Y = (int)currentPosition.y + (int)cellSize / 2 - trapWidth;
                int trap2Y = (int)currentPosition.y - (int)cellSize / 2 + trapWidth;

                GameObject trap1 = Instantiate(trapSquarePrefab, new Vector3(trapX, trap1Y), Quaternion.identity);
                GameObject trap2 = Instantiate(trapSquarePrefab, new Vector3(trapX, trap2Y), Quaternion.identity);
            }

            else if(n > 20 && n < 29)
            {
                int trap1X = (int)currentPosition.x - (int)cellSize / 2 + trapWidth;
                int trap2X = (int)currentPosition.x - trapWidth;
                int trap3X = (int)currentPosition.x + trapWidth;
                int trap4X = (int)currentPosition.x + (int)cellSize / 2 - trapWidth;
                int trap1Y = (int)currentPosition.y;
                int trap2Y = (int)currentPosition.y - (int)cellSize / 2 + trapWidth;

                GameObject trap1 = Instantiate(trapSquarePrefab, new Vector3(trap1X, trap2Y), Quaternion.identity);
                GameObject trap2 = Instantiate(trapSquarePrefab, new Vector3(trap4X, trap2Y), Quaternion.identity);
                GameObject trap3 = Instantiate(trapSquarePrefab, new Vector3(trap2X, trap1Y), Quaternion.identity);
                GameObject trap4 = Instantiate(trapSquarePrefab, new Vector3(trap3X, trap1Y), Quaternion.identity);
            }

            else if(n > 60 && n > 69)
            {
                int trap1X = (int)currentPosition.x - (int)cellSize / 2 + trapWidth;
                int trap2X = (int)currentPosition.x;
                int trap3X = (int)currentPosition.x + (int)cellSize / 2 - trapWidth;
                int trap1Y = (int)currentPosition.y - (int)cellSize / 2 + trapWidth;
                int trap2Y = (int)currentPosition.y;
                int trap3Y = (int)currentPosition.y + (int)cellSize / 2 - trapWidth;

                GameObject trap1 = Instantiate(trapSquarePrefab, new Vector3(trap1X, trap1Y), Quaternion.identity);
                GameObject trap2 = Instantiate(trapSquarePrefab, new Vector3(trap1X, trap3Y), Quaternion.identity);
                GameObject trap3 = Instantiate(trapSquarePrefab, new Vector3(trap2X, trap2Y), Quaternion.identity);
                GameObject trap4 = Instantiate(trapSquarePrefab, new Vector3(trap3X, trap1Y), Quaternion.identity);
                GameObject trap5 = Instantiate(trapSquarePrefab, new Vector3(trap3X, trap3Y), Quaternion.identity);
            }

            else if(n > 80 && n < 89)
            {
                int trapX = (int)currentPosition.x;
                int trapY = (int)currentPosition.y;

                GameObject trap = Instantiate(trapSquarePrefab, new Vector3(trapX, trapY), Quaternion.identity);
            }

            else if(n > 90 && n < 95)
            {
                int trap1X = (int)currentPosition.x - (int)cellSize / 2 + trapWidth;
                int trap2X = (int)currentPosition.x;
                int trap3X = (int)currentPosition.x + (int)cellSize / 2 - trapWidth;
                int trap1Y = (int)currentPosition.y - (int)cellSize / 2 + trapWidth;
                int trap2Y = (int)currentPosition.y + (int)cellSize / 2 - trapWidth;

                GameObject trap1 = Instantiate(trapSquarePrefab, new Vector3(trap1X, trap1Y), Quaternion.identity);
                GameObject trap2 = Instantiate(trapSquarePrefab, new Vector3(trap2X, trap1Y), Quaternion.identity);
                GameObject trap3 = Instantiate(trapSquarePrefab, new Vector3(trap3X, trap1Y), Quaternion.identity);
                GameObject trap4 = Instantiate(trapSquarePrefab, new Vector3(trap1X, trap2Y), Quaternion.identity);
                GameObject trap5 = Instantiate(trapSquarePrefab, new Vector3(trap2X, trap2Y), Quaternion.identity);
                GameObject trap6 = Instantiate(trapSquarePrefab, new Vector3(trap3X, trap2Y), Quaternion.identity);
            }

            if(n > 40 && n < 60 && chaosGate == false)
            {
                int gateWidth = 3;
                int gateX = random.Next((int)currentPosition.x - (int)cellSize / 2 + gateWidth, (int)currentPosition.x + (int)cellSize / 2 - gateWidth);
                int gateY = random.Next((int)currentPosition.y - (int)cellSize / 2 + gateWidth, (int)currentPosition.y + (int)cellSize / 2 - gateWidth);

                GameObject gate = Instantiate(chaosGatePrefab, new Vector3(gateX, gateY), Quaternion.identity);
                chaosGate = true;
            }

            gridCellList.Add(new GridCell(currentPosition));

            GameObject openBarrier = Instantiate(barrierOpen, new Vector3(newX, newY), Quaternion.identity);

            if (secondPos)
            {
                gridCellList.Add(new GridCell(secondPosition));
                GameObject openDoors = Instantiate(barrierOpen, new Vector3(secX, secY), Quaternion.identity);
                secondPos = false;
            }

            if(endBox)
            {
                GameObject endBarrier = Instantiate(barrierTopPrefab, new Vector3(newX, newY), Quaternion.identity);
                endBox = false;
            }
        }
    }

    IEnumerator CreatePathRoutine() 
    {
        gridCellList.Clear();
        Vector2 currentPosition = new Vector2(0f, 0f);
        Vector2 secondPosition = currentPosition;

        gridCellList.Add(new GridCell(currentPosition));

        for (int i = 0; i < pathLength; i++)
        {
            int n = random.Next(100);

            if (n > 0 && n < 59)
            {
                currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
                secondPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
                Debug.Log("second position");
                secondPos = true;
            }
            else if (n > 60 && n < 79)
            {
                currentPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
            }
            else
            {
                currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
            }

            float currX = currentPosition.x + cellSize / 2;
            float currY = currentPosition.y;
            float secX = secondPosition.x + cellSize / 2;
            float secY = secondPosition.y;
          //  GameObject barrier = Instantiate(, new Vector3(currX, currY), Quaternion.identity);
          //  GameObject barrier1 = Instantiate(barrierPrefab, new Vector3(secX, secY), Quaternion.identity);

            gridCellList.Add(new GridCell(currentPosition));

            if (secondPos)
            {
                gridCellList.Add(new GridCell(secondPosition));
                secondPos = false;
            }

            yield return null;
        }
    }

    private void OnDrawGizmos() 
    {
        for (int i = 0; i < gridCellList.Count; i++) 
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(gridCellList[i].location, Vector2.one * cellSize);
            Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            Gizmos.DrawCube(gridCellList[i].location, Vector2.one * cellSize);
        }
    }
}
