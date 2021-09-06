using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
    {
        public Vector3 offset = Vector3.up * 10f;

        public float speed = 1f;
        public float pause = 1f;

        public bool smooth = true;

        Vector3 start, end;

        float lerpTime = 0.0f;
        float pauseTime = 0.0f;

        bool reverse = false;
        bool paused = false;

        private void Start()
        {
            start = transform.position;
            end = transform.position += offset;
        }

        private void Update()
        {
            if ((!reverse && Vector3.Distance(transform.position, end) < 0.1f) ||
                (reverse && Vector3.Distance(transform.position, start) < 0.1f))
            {
                reverse = !reverse;
                paused = true;
            }

            if (smooth)
                transform.position = Vector3.Lerp(start, end, Mathf.SmoothStep(0.0f, 1.0f, lerpTime));
            else
                transform.position = Vector3.Lerp(start, end, lerpTime);

            if (!paused)
                lerpTime += reverse ? -Time.deltaTime * speed : Time.deltaTime * speed;
            else
                pauseTime += Time.deltaTime;

            if (pauseTime >= pause)
            {
                pauseTime = 0.0f;
                paused = false;
            }
        }
    }
