using UnityEngine;

namespace Weapon
{
    public class WeaponHolderFiner : MonoBehaviour
    {
        internal static Transform FindDeepChild(Transform parent, string name)
        {
            foreach (Transform child in parent)
            {
                if (child.name == name)
                {
                    return child; // Если объект найден, вернуть его
                }

                // Рекурсивный вызов функции для поиска в дочерних объектах
                Transform result = FindDeepChild(child, name);
                if (result != null)
                {
                    return result; // Если объект найден в дочерних объектах, вернуть его
                }
            }

            return null; // Если объект не найден, вернуть null
        }
    }
}
