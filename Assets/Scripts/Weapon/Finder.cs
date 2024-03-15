using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{
    internal static GameObject FindDeepChild(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child.gameObject;
            }
            else
            {
                GameObject found = FindDeepChild(child, name);
                if (found != null)
                    return found;
            }
        }
        return null;
    }
}
