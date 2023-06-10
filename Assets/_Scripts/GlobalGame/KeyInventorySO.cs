using UnityEngine;

namespace KeyInventory
{
    [CreateAssetMenu(fileName = "KeyInventory", menuName = "Inventory/KeyInventory")]
    public class KeyInventorySO : ScriptableObject
    {
        public int normalKey;
        public int storyKey;
        
        public void LoadKeys()
        {
            normalKey = PlayerPrefs.GetInt(PlayerPrefsLibrary.NormalKeyPlayerPrefsKey, 0);
            storyKey = PlayerPrefs.GetInt(PlayerPrefsLibrary.StoryKeyPlayerPrefsKey, 0);
        }

        public void SaveKeys()
        {
            PlayerPrefs.SetInt(PlayerPrefsLibrary.NormalKeyPlayerPrefsKey, normalKey);
            PlayerPrefs.SetInt(PlayerPrefsLibrary.StoryKeyPlayerPrefsKey, storyKey);
        }

        public void AddKey(bool isNormalKey = false)
        {
            if (isNormalKey)
            {
                normalKey++;
            }
            else
            {
                storyKey++;
            }
            SaveKeys();
        }

        public void UseKey(bool isNormalKey)
        {
            if (isNormalKey)
            {
                normalKey--;
            }
            else
            {
                storyKey--;
            }
            SaveKeys();
        }

        public int GetNormalKeyCount()
        {
            LoadKeys();
            return normalKey;
        }

        public int GetStoryKeyCount()
        {
            LoadKeys();
            return storyKey;
        }
    }
}