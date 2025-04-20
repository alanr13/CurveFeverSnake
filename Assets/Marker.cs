using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public class Marker
    {
        public Quaternion rotation;

        public Marker(Quaternion rotation)
        {
            this.rotation = rotation;
        }
    }

    public List<Marker> markers = new List<Marker>();

    void Start()
    {
        
    }
    void FixedUpdate()
    {
        AddToMarkersList();
    }

    public void AddToMarkersList()
    {
        markers.Add(new Marker(transform.rotation));
    }

    public void ClearMarkersList()
    {
        markers.Clear();
        markers.Add(new Marker(transform.rotation));
    }
}
