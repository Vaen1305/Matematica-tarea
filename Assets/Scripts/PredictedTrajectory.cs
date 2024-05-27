using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedTrajectory : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float maxLaunchForce = 20f;
    public float minLaunchForce = 5f;
    public float maxChargeTime = 1f;
    public LineRenderer lineRenderer;
    public int resolution = 30;

    private float currentLaunchForce;
    private float chargeSpeed;
    private bool aiming;
    private Vector3 aimDirection;
    private Vector3 initialMousePosition;

    void Start()
    {
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
        lineRenderer.positionCount = resolution;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartAiming();
        }
        else if (Input.GetButton("Fire1") && aiming)
        {
            AimAndCharge();
        }
        else if (Input.GetButtonUp("Fire1") && aiming)
        {
            Launch();
        }
    }

    void StartAiming()
    {
        aiming = true;
        currentLaunchForce = minLaunchForce;
        initialMousePosition = Input.mousePosition;
    }

    void AimAndCharge()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        float distance = Vector3.Distance(initialMousePosition, currentMousePosition);
        currentLaunchForce = Mathf.Lerp(minLaunchForce, maxLaunchForce, distance / Screen.height);
        currentLaunchForce = Mathf.Clamp(currentLaunchForce, minLaunchForce, maxLaunchForce);

        Ray camRay = Camera.main.ScreenPointToRay(currentMousePosition);
        Vector3 mouseDirection = camRay.direction.normalized;

        float dotUp = Vector3.Dot(mouseDirection, Vector3.up);
        float dotForward = Vector3.Dot(mouseDirection, Camera.main.transform.forward);

        if (dotUp > dotForward)
        {
            aimDirection = Vector3.up * maxLaunchForce;
        }
        else
        {
            aimDirection = mouseDirection * maxLaunchForce;
        }

        ShowTrajectory(launchPoint.position, aimDirection.normalized * currentLaunchForce);
    }

    void Launch()
    {
        aiming = false;
        GameObject projectileInstance = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        Rigidbody rb = projectileInstance.GetComponent<Rigidbody>();
        rb.velocity = aimDirection.normalized * currentLaunchForce;

        lineRenderer.positionCount = 0;
    }

    void ShowTrajectory(Vector3 startPoint, Vector3 initialVelocity)
    {
        Vector3 gravity = Physics.gravity;
        Vector3 position = startPoint;
        Vector3 velocity = initialVelocity;

        lineRenderer.positionCount = resolution;
        for (int i = 0; i < resolution; i++)
        {
            position += velocity * 0.1f + 0.5f * gravity * 0.1f * 0.1f;
            velocity += gravity * 0.1f;
            lineRenderer.SetPosition(i, position);
        }
    }
}
