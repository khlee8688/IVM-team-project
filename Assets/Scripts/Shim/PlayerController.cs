using System.Collections;
using System.Collections.Generic;
using Meta.WitAi.Attributes;
using Meta.XR.MRUtilityKit.SceneDecorator;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject cursorPoint1;
    GameObject cursorPoint2;
    GameObject rayCylinder1;
    GameObject rayCylinder2;
    GameObject insideRayCylinder1;
    GameObject insideRayCylinder2;
    public GameObject player;
    public GameObject leftHand;
    public GameObject rightHand;
    public Material rayMaterial;
    public Material insideRayMaterial;

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
        {
            Debug.Log("player is not assigned");
        }
        if (!leftHand)
        {
            Debug.Log("leftHand is not assigned");
        }
        if (!rightHand)
        {
            Debug.Log("rightHand is not assigned");
        }
        if (!rayMaterial)
        {
            Debug.Log("rayMaterial is not assigned");
        }
        if (!insideRayMaterial)
        {
            Debug.Log("insideRayMaterial is not assigned");
        }

        cursorPoint1 = CreateCursor("cursorPoint1", Color.white);
        cursorPoint2 = CreateCursor("cursorPoint2", Color.white);

        rayCylinder1 = CreateRay("RayCylinder1", rayMaterial, new Vector3(0.0055f, 1f, 0.0055f));
        rayCylinder2 = CreateRay("RayCylinder2", rayMaterial, new Vector3(0.0055f, 1f, 0.0055f));

        insideRayCylinder1 = CreateRay("InsideRayCylinder1", insideRayMaterial, new Vector3(0.005f, 1f, 0.005f));
        insideRayCylinder2 = CreateRay("InsideRayCylinder2", insideRayMaterial, new Vector3(0.005f, 1f, 0.005f));

        SetActiveRayObjects(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRay(rightHand, rightHand.transform.position, ref cursorPoint1, ref rayCylinder1, ref insideRayCylinder1, 1);
        UpdateRay(leftHand, leftHand.transform.position, ref cursorPoint2, ref rayCylinder2, ref insideRayCylinder2, 2);
    }

    GameObject CreateCursor(string name, Color color)
    {
        GameObject cursor = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        cursor.name = name;
        cursor.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Renderer renderer = cursor.GetComponent<Renderer>();
        renderer.material.color = color;
        renderer.receiveShadows = false;
        Destroy(cursor.GetComponent<Collider>());
        return cursor;
    }

    GameObject CreateRay(string name, Material material, Vector3 scale)
    {
        GameObject ray = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        ray.name = name;
        ray.transform.localScale = scale;
        Renderer renderer = ray.GetComponent<Renderer>();
        if (material != null)
        {
            renderer.material = material;
        }
        renderer.receiveShadows = false;
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        Destroy(ray.GetComponent<Collider>());
        return ray;
    }

    void UpdateRay(GameObject controller, Vector3 startPoint, ref GameObject cursor, ref GameObject outerRay, ref GameObject innerRay, int num)
    {
        RaycastHit hit;
        Vector3 endPoint;

        if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit)
            && hit.collider != null
            && (hit.collider.gameObject.CompareTag("NPC") || hit.collider.gameObject.CompareTag("Button")))
        {
            SetActiveRayObjects(true, num);
            endPoint = hit.point;
            cursor.transform.position = hit.point;
            HandleTriggers();
        }
        else
        {
            SetActiveRayObjects(false, num);
            endPoint = controller.transform.position + controller.transform.forward * 20f;
            if (cursor != null)
            {
                cursor.transform.position = endPoint;
            }
        }

        var direction = endPoint - startPoint;
        outerRay.transform.position = (startPoint + endPoint) / 2;
        innerRay.transform.position = outerRay.transform.position;

        Quaternion lookRot = Quaternion.LookRotation(direction);
        Quaternion tiltRot = Quaternion.Euler(0, 90, 90);
        if (direction != Vector3.zero)
        {
            outerRay.transform.rotation = lookRot * tiltRot;
            innerRay.transform.rotation = lookRot * tiltRot;
        }

        float distance = direction.magnitude / 2;
        Vector3 scale = outerRay.transform.localScale;
        outerRay.transform.localScale = new Vector3(scale.x, distance, scale.z);
        innerRay.transform.localScale = new Vector3(scale.x, distance, scale.z);
    }

    void SetActiveRayObjects(bool isActive, int num = 0)
    {
        if (num == 0 || num == 1)
        {
            if (cursorPoint1 != null) cursorPoint1.SetActive(isActive);
            if (rayCylinder1 != null) rayCylinder1.SetActive(isActive);
            if (insideRayCylinder1 != null) insideRayCylinder1.SetActive(isActive);
        }

        if (num == 0 || num == 2)
        {
            if (cursorPoint2 != null) cursorPoint2.SetActive(isActive);
            if (rayCylinder2 != null) rayCylinder2.SetActive(isActive);
            if (insideRayCylinder2 != null) insideRayCylinder2.SetActive(isActive);
        }
    }

    void HandleTriggers()
    {
        bool handRight = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        bool R_secondaryTrigger = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.RTouch);

        bool handLeft = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        bool L_secondaryTrigger = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.LTouch);

        if (handRight || R_secondaryTrigger)
        {
            RaycastHit hit1;
            if (Physics.Raycast(rightHand.transform.position, rightHand.transform.forward, out hit1))
            {
                // target.transform.position = hit1.point;
                InteractionManager.Instance.Interact(hit1.collider.gameObject);
            }
        }

        if (handLeft || L_secondaryTrigger)
        {
            RaycastHit hit2;
            if (Physics.Raycast(leftHand.transform.position, leftHand.transform.forward, out hit2))
            {
                player.transform.position = new Vector3(hit2.point.x, player.transform.position.y, hit2.point.z);
            }
        }
    }
}
