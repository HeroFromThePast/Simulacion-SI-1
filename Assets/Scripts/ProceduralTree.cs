using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTree : MonoBehaviour
{
    private const int IndexOfSquareChild = 0;
    private const int IndexOfCircleChild = 1;
    
    [SerializeField] GameObject branchPrefab;
    [SerializeField] int totalLevels = 3;
    [SerializeField] float initialSize = 5;
    [SerializeField, Range(0f, 1f)] float reductionPerLevel = 0.1f;
    int currentLevel = 1;
    private Queue<GameObject> branchesQueue = new Queue<GameObject>();
    private void Start()
    {
        GameObject rootBranch = Instantiate(branchPrefab, transform);
        branchesQueue.Enqueue(rootBranch);
        ChangeBranchSize(rootBranch, initialSize);
        GenerateTree();
        
    }

    void GenerateTree()
    {
        if(currentLevel >= totalLevels)
        {
            return;
        }

        ++currentLevel;

        float newSize = Mathf.Max(initialSize - initialSize * reductionPerLevel * (currentLevel - 1), 0.1f);
        List<GameObject> branchesCreatedThisCycle = new List<GameObject>();

        while(branchesQueue.Count > 0)
        {
            var rootBranch = branchesQueue.Dequeue();

            var leftBranch = CreateBranch(rootBranch, Random.Range(5f, 20f));
            var rightBranch = CreateBranch(rootBranch, -Random.Range(5f, 20f));

            ChangeBranchSize(leftBranch, newSize);
            ChangeBranchSize(rightBranch, newSize);
            
            branchesCreatedThisCycle.Add(leftBranch);
            branchesCreatedThisCycle.Add(rightBranch);
        }

        foreach (var newBranches in branchesCreatedThisCycle)
        {
            branchesQueue.Enqueue(newBranches);
        }

        GenerateTree();
    }
    GameObject CreateBranch(GameObject prevBranch, float relativeAngle)
    {
        GameObject newBranch = Instantiate(branchPrefab, transform);
        newBranch.transform.position = prevBranch.transform.localPosition + prevBranch.transform.up * GetBranchLenght(prevBranch);
        newBranch.transform.rotation = prevBranch.transform.rotation * Quaternion.Euler(0, 0, relativeAngle);

        return newBranch;
    }

    void ChangeBranchSize(GameObject branchInstance, float newSize)
    {
        var square = branchPrefab.transform.GetChild(IndexOfSquareChild);
        var branchEnd = branchPrefab.transform.GetChild(IndexOfCircleChild);

        var newScale = square.transform.localScale;
        newScale.y = newSize;
        square.transform.localScale = newScale;

        var newPosition = square.transform.localPosition;
        newPosition.y = newSize / 2f;
        square.transform.localPosition = newPosition;
        
        var newCirclePosition = branchEnd.transform.localPosition;
        newCirclePosition.y = newSize;
        branchEnd.transform.localPosition = newCirclePosition;

        
    }

    private float GetBranchLenght(GameObject branchInstance)
    {
        return branchInstance.transform.GetChild(IndexOfSquareChild).localScale.y;
    }
}
