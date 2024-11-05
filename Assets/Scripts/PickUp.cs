using UnityEngine;

public class PickUp : MonoBehaviour
{
    //public Transform theDest;
    
    private bool isFingersBent = false;
    // ���������� ��� ����������� �������� �������
    public GameObject[] pickableObjects;

   
    
    void Awake()
    {
        pickableObjects = GameObject.FindGameObjectsWithTag("objects");
        // ������ ����������� ��������
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
            // ������ ������ ������� - ����� ����� �������� �������� ������������� ����� � ���������
            // ��������, ����� �������� ��������� ������ � ���� ������ ��� ������ � ������������� ����������������
            GameObject nearestObject = FindNearestObject();

            // ����� ����� �������� ������ ��� ��������/����������� ������� �������
            if (nearestObject != null)
            {
                // �������� ��� �������� �������, ��������:
                nearestObject.transform.SetParent(transform); 
                // ������� ������
                nearestObject.transform.localPosition = new Vector3(0, 15, 5); 
                // ��������� ������� ������������ ����
            }
        }
    }

    GameObject FindNearestObject()
    {
        // ��������� ����� ��� ������ ���������� ������� � ������� pickableObjects
        // ����� ����� ����������� ���� ������ ������������� ����� � ��������� � ������ �������� �����������
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
        // ������: ���� ������ ������� 1, �������, ��� ������ �������
        if (Input.GetButton("fistKey"))
        {
            isFingersBent = true;
            PickObject();
            // �������� ����� ��� ������ �������
            //Debug.Log("Script PickUp is Working");
        }
        // ���� ������� 1 ��������, �������, ��� ������ ���������
        else if (Input.GetButton("fistKey"))
        {
            isFingersBent = false;
        }
    }

}
