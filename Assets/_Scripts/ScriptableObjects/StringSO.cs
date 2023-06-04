using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/String", fileName = "NewString")]
public class StringSO : ScriptableObject
{
    [SerializeField] private string Value;
    public string value => Value;
}
