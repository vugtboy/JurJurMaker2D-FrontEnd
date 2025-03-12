using System.Collections.Generic;
using System;
using UnityEngine;

//zodat lists opgehaald kunne worden met de API
public static class JsonHelper
{
    public static List<T> ParseJsonArray<T>(string jsonArray)
    {
        string extendedJson = "{\"list\":" + jsonArray + "}";
        JsonList<T> parsedList = JsonUtility.FromJson<JsonList<T>>(extendedJson);
        return parsedList.list;
    }
}

[Serializable]
public class JsonList<T>
{
    public List<T> list;
}