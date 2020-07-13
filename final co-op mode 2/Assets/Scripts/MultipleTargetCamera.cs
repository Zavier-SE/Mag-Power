﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{

	public List<Transform> targets;

	public Vector3 offset;
	public float smoothTime = 0.5f;

	public float minZoom = 40f;
	public float maxZoom = 10f;
	public float zoomLimiter;

	public bool bounds;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	private Vector3 velocity;
	private Camera cam;

	void Start()
	{

		cam = GetComponent<Camera>();

	}

	void LateUpdate()
	{

		if(targets.Count == 0)
			return;

		Move();
		Zoom();
		

	}

	void Zoom()
	{

		float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
	}

	void Move()
	{

		Vector3 centerPoint = GetCenterPoint();

		Vector3 newPosition = centerPoint + offset;

		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

		if(bounds)
		{

			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

		}

	}

	float GetGreatestDistance()
	{

		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for (int i = 0;i< targets.Count; i++)
		{

			bounds.Encapsulate(targets[i].position);

		}

		return bounds.size.x;

	}

	Vector3 GetCenterPoint()
	{

		if (targets.Count == 1){

			return targets[0].position;

		}

		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for (int i = 0;i< targets.Count; i++)
		{

			bounds.Encapsulate(targets[i].position);

		}

		return bounds.center;

	}

}
