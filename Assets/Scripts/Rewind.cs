using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    private Dictionary<GameObject, List<RewindObjectData>> rewindDataDict = new Dictionary<GameObject, List<RewindObjectData>>();
    private bool isRewinding = false;
    private float recordDuration = 2f; // Kaydedilecek süre (2 saniye)

    private class RewindObjectData
    {
        public float time; // Zaman damgasý
        public Vector2 position;
        public float rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            StartRewind();
        else if (Input.GetKeyUp(KeyCode.R))
            StopRewind();

        if (isRewinding)
            RewindM();
        else
            Record();
    }

    private void Record()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Recordable"))
        {
            if (!rewindDataDict.ContainsKey(obj))
                rewindDataDict[obj] = new List<RewindObjectData>();

            RewindObjectData data = new RewindObjectData
            {
                time = Time.time, // Zaman damgasýný þu anki zamana ayarla
                position = obj.transform.position,
                rotation = obj.transform.rotation.eulerAngles.z
            };

            rewindDataDict[obj].Add(data);

            // Son 2 saniyeden eski kayýtlarý temizle
            float timeThreshold = Time.time - recordDuration;
            rewindDataDict[obj].RemoveAll(d => d.time < timeThreshold);
        }
    }

    private void RewindM()
    {
        foreach (var kvp in rewindDataDict)
        {
            GameObject obj = kvp.Key;
            List<RewindObjectData> dataList = kvp.Value;

            if (dataList.Count > 0)
            {
                RewindObjectData data = dataList[dataList.Count - 1];
                obj.transform.position = data.position;
                obj.transform.rotation = Quaternion.Euler(0f, 0f, data.rotation);
                dataList.RemoveAt(dataList.Count - 1);
            }
        }
    }

    private void StartRewind()
    {
        isRewinding = true;
    }

    private void StopRewind()
    {
        isRewinding = false;
    }
}
