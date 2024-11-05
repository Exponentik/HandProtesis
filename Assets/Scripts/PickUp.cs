using UnityEngine;

public class PickUp : MonoBehaviour
{
    //public Transform theDest;
    
    private bool isFingersBent = false;
    // Переменная для определения сгибания пальцев
    public GameObject[] pickableObjects;

   
    
    void Awake()
    {
        pickableObjects = GameObject.FindGameObjectsWithTag("objects");
        // Массив подбираемых объектов
    }

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        //this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("myhand").transform;
    }


    void PickObject()
    {
        if (isFingersBent)
        {
            // Логика выбора объекта - здесь можно добавить алгоритм сопоставления жеста с объектами
            // Например, можно выбирать ближайший объект к руке игрока или объект с определенными характеристиками
            GameObject nearestObject = FindNearestObject();

            // Далее можно добавить логику для поднятия/перемещения объекта игроком
            if (nearestObject != null)
            {
                // Действия для поднятия объекта, например:
                nearestObject.transform.SetParent(transform); 
                // Поднять объект
                nearestObject.transform.localPosition = new Vector3(0, 15, 5); 
                // Положение объекта относительно руки
            }
        }
    }

    GameObject FindNearestObject()
    {
        // Примерный метод для поиска ближайшего объекта в массиве pickableObjects
        // Здесь нужно реализовать вашу логику сопоставления жеста с объектами и выбора наиболее подходящего
        GameObject nearestObject = null;
        float nearestDistance = Mathf.Infinity;
        Vector3 handPosition = transform.position;
        //handPosition.y = 15;

        foreach (GameObject obj in pickableObjects)
        {
            float distance = Vector3.Distance(obj.transform.position + new Vector3(0, 15, 5), handPosition);
            if (distance < nearestDistance)
            {
                nearestObject = obj;
                nearestDistance = distance;
            }
        }

        return nearestObject;
    }


    void Update()
    {
        // Пример: если нажата клавиша 1, считаем, что пальцы согнуты
        if (Input.GetButton("fistKey"))
        {
            isFingersBent = true;
            PickObject();
            // Вызываем метод для выбора объекта
            //Debug.Log("Script PickUp is Working");
        }
        // Если клавиша 1 отпущена, считаем, что пальцы разогнуты
        else if (Input.GetButton("fistKey"))
        {
            isFingersBent = false;
        }
    }

}
