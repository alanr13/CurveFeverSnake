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

    public void AddToMarkersList(List<Transform> bodyParts)
    {
        for (int i = 0; i < bodyParts.Count; i++)
        {
            markers.Add(new Marker(bodyParts[i].transform.position, bodyParts[i].transform.rotation));
        }
    }
}
