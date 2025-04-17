using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public class Marker
    {
        public Vector3 position;
        public Quaternion rotation;

        public Marker(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }

    public List<Marker> markers = new List<Marker>();

    void FixedUpdate()
    {
        AddToMarkersList();
    }

    public void AddToMarkersList()
    {
        for (int i = 0; i < 4; i++)
        {
            markers.Add(new Marker(transform.position, transform.rotation));
        }
    }
}
