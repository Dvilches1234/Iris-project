using UnityEngine;
using System.Globalization;
using Player;
namespace UI
{
    public static class PlayerPrefsController
    {
        private static float health;
        private static float mana;
        private static int keys;
        private static int gems;
        private static int sceneIndex;
        private static Vector3 playerPos;

        private static bool onLevel = false;

        public static void SavePlayerPos(Vector3 newPos)
        {
            playerPos = newPos;
            string playerPosStr = playerPos.ToString();
            PlayerPrefs.SetString("PlayerPos", playerPosStr);
        }

        public static Vector3 GetPlayerPos()
        {
            string playerPosStr = PlayerPrefs.GetString("PlayerPos", "");
            if (playerPosStr == "")
            {
                return Vector3.zero;
            }
            playerPosStr = playerPosStr.Remove(0,1 );
            Debug.Log(playerPosStr);
            playerPosStr = playerPosStr.Remove(playerPosStr.Length - 1,1 );
            Debug.Log(playerPosStr);
            string[] coordinates = playerPosStr.Split(",");
            float[] fCoordinates = new float[3];
            for (int i = 0; i < 3; i++)
            {
                Debug.Log(coordinates[i]);
                fCoordinates[i] = float.Parse(coordinates[i], CultureInfo.InvariantCulture.NumberFormat);
            }
            playerPos = new Vector3(fCoordinates[0], fCoordinates[1], fCoordinates[2]);
            Debug.Log(playerPos);
            return playerPos;
        }

        public static void SavePlayerResources(float newHealth, float newMana)
        {
            health = newHealth;
            mana = newMana;
            PlayerPrefs.SetFloat("Health",health);
            PlayerPrefs.SetFloat("Mana", mana);
        }
        public static float[] GetPlayerResources()
        {
            float[] resources = new float[2];
            health = PlayerPrefs.GetFloat("Health");
            mana = PlayerPrefs.GetFloat("Mana");
            resources[0] = health;
            resources[1] = mana;
            return resources;
        }
        public static void SavePlayerPoints(int newKeys, int newGems)
        {
            keys = newKeys;
            gems = newGems;
            PlayerPrefs.SetInt("Keys",keys);
            PlayerPrefs.SetInt("Gems", gems);
        }
        public static int[] GetPlayerPoints()
        {
            int[] points = new int[2];
            keys = PlayerPrefs.GetInt("Keys");
            gems = PlayerPrefs.GetInt("Gems");
            points[0] = keys;
            points[1] = gems;
            return points;
        }

        public static void SaveSceneIndex(int index)
        {
            sceneIndex = index;
            PlayerPrefs.SetInt("SceneIndex", sceneIndex);
        }

        public static int GetSceneIndex()
        {
            sceneIndex = PlayerPrefs.GetInt("SceneIndex");
            return sceneIndex;
        }

        public static void SetSaved()
        {
            PlayerPrefs.SetString("Saved", "Saved");
        }

        public static bool IsASave()
        {
            return PlayerPrefs.GetString("Saved", "") == "Saved";
        }

        public static void Delete()
        {
            PlayerPrefs.DeleteAll();
        }

        public static void SetOnLevel(bool newStatus) 
        {
            onLevel = newStatus;
        }

        public static bool IsOnLevel()
        {
            return onLevel;
        }


    }
}
