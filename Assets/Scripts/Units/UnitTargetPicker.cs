using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTargetPicker : MonoBehaviour
{
    List<GameObject> objectList = new List<GameObject>();
    List<GameObject> enemyList = new List<GameObject>();
    List<GameObject> materialList = new List<GameObject>();//do we need 2????? must rework make one list
    [SerializeField] public GameObject combatTarget;
    public GameObject materialTarget;
    [SerializeField] string targetName;

    public bool enemyListEmpty;
    //redo stuff 
    //public string enemyTag = "EnemyUnit";
    public string tagOfEnemy;
    public string tagOfMaterial = "Material";//temporary must rework

    public void FindClosestEnemy()
    {
        combatTarget = GetClosestObjectWithTag(enemyList,tagOfEnemy);
    }
    public void FindClosestMaterialSource()
    {
        materialTarget = GetClosestObjectWithTag(materialList,tagOfMaterial);
    }


    public GameObject GetClosestObjectWithTag(List<GameObject>list ,string tag)
    {
        ListObjectsWithTag(list, tag);
        //Debug.Log(list.Count);
        if (list.Count > 0)
        {
            return GetClosestObjectOfProvidedList(list);
        }
        else { return null; }
    }

    void ListObjectsWithTag(List<GameObject> list, string tag)
    {
        //Debug.Log("Listing objects");
        list.Clear();
        //Debug.Log("ObjectList cleared");
        //Debug.Log(list.Count);
        if (this.transform.parent != null)//this is just to hceck if its null to avoid crash
        {
            foreach (Transform transformObject in this.transform.parent)
            {
                if (transformObject.gameObject.tag == tag)
                { list.Add(transformObject.gameObject); }
            }
        }
        else
        {
            Debug.LogWarning("Parent transform is null. No objects to list.");
        }
    }
    GameObject GetClosestObjectOfProvidedList(List<GameObject> providedList)
    {
        //Debug.Log("Finding target");
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        //Debug.Log($"log entry prior to search in list+ listcount: "+providedList.Count);
        foreach (GameObject potentialTarget in providedList)
        {//find closest
            //Debug.Log("finding target in provided list");
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        //Debug.Log("Finding target OK");
        return bestTarget;
    }

}
    /*public void FindClosestEnemy2()
    {
        //Debug.Log("FINDING ENEMIES");
        //ListObjectsInMap();
        //ListEnemies();
        //GetClosestObject(enemyList);// ************ temp shutdown
    }*/
    /*
    public GameObject FindClosestObjectOfTag(string tag, List <GameObject> listOfTagged)
    {
        GameObject closestObject=null;
        //ListObjectsInMap();
        ListObjectsOfType(tag,listOfTagged);
        if (listOfTagged.Count > 1)
        {
            closestObject = GetClosestObject(listOfTagged);
        }

        return closestObject;
    }*/
    /*
    void ListObjectsInMap()
    {
        //Debug.Log("Listing objects");
        objectList.Clear();
        //Debug.Log("ObjectList cleared");

        Transform parentTransform = this.transform.parent;
        if (parentTransform != null)//this is just to hceck if its null to avoid crash
        {
            foreach (Transform transformObject in parentTransform)
            {
                objectList.Add(transformObject.gameObject);
            }
            //Debug.Log($"Listing objects OK, listCount: "+objectList.Count);
        }
        else
        {
            Debug.LogWarning("Parent transform is null. No objects to list.");
        }
    }*/
    /*
    void ListEnemies()
    {
        //Debug.Log("Listing enemies");
        enemyList.Clear();
        foreach (GameObject gameObject in objectList)
        {
            //Debug.Log($"Object: {gameObject.name}, Tag: {gameObject.tag}");
            if (gameObject.tag == tagOfEnemy)
            {//if problem here we fucked...
                enemyList.Add(gameObject);
                //Debug.Log("logged enemy into enemyList");
            }
        }
        if (enemyList.Count == 0)
        { enemyListEmpty = true; }
        else { enemyListEmpty = false; }
        //Debug.Log("Listing enemies OK");
    }*/
    /*
    void ListMatsObjects(string resource, List <GameObject> list)// list enemies list mats objects need just one method fix this!!!!!!!!!!!!!!!!!
    {
        //Debug.Log("Listing enemies");
        enemyList.Clear();
        foreach (GameObject gameObject in objectList)
        {
            //Debug.Log($"Object: {gameObject.name}, Tag: {gameObject.tag}");
            if (gameObject.tag == resource)
            {
                list.Add(gameObject);
                //Debug.Log("logged enemy into enemyList");
            }
        }
        if (enemyList.Count == 0)
        { enemyListEmpty = true; }
        else { enemyListEmpty = false; }
    }
    void ListObjectsOfType(string tag, List<GameObject> list)// list enemies list mats objects need just one method fix this!!!!!!!!!!!!!!!!!
    {
        //Debug.Log("Listing enemies");
        list.Clear();
        foreach (GameObject gameObject in objectList)
        {
            //Debug.Log($"Object: {gameObject.name}, Tag: {gameObject.tag}");
            if (gameObject.tag == tag)
            {
                list.Add(gameObject);
                //Debug.Log("logged enemy into enemyList");
            }
        }
    }

    /* 
    GameObject GetClosestObject(List<GameObject> providedList)
        //******************* must fix this so it sets target only as return
    {//this may be broken
        //Debug.Log("Finding target");
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        //Debug.Log($"log entry prior to search in list+ listcount: "+providedList.Count);

        foreach (GameObject potentialTarget in providedList)
        {//find closest
            //Debug.Log("finding target in provided list");
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        //Debug.Log("Finding target OK");
        //return bestTarget;

        if (bestTarget == null)
        { FindClosestEnemy(); return target; }//bs so it wont bitch  //this whole if will be removed when we make sure method is run only when there lsit to check
        else { return bestTarget; }
    }*/



    /*
    target = bestTarget;//********* temp shutdown
    if (target == null) // ******* has to be local variable over parameter 
    { 
        //Debug.Log("target NULL in unit target picker");
        FindClosestEnemy();
    }
    //Debug.Log(target.name);
    //returning closest gameObject
    targetName = target.name;
    //Debug.Log($"target returned:" +targetName);
    return target;// ********** temo shutdown
    //return bestTarget;
    */

    /*
    void ListEnemies()
    {
        //Debug.Log("Listing enemies");
        enemyList.Clear();
        foreach (GameObject gameObject in objectList)
        {
            Debug.Log("noticed object in objectList");
            if (gameObject.tag == enemyTag)
            { 
                enemyList.Add(gameObject);
                Debug.Log("logged enemy into enemyList");
            }
        }
        Debug.Log($"Listing enemies OK, listCount is: "+enemyList.Count);
    }
    */
