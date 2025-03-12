using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//deze klasse is voledig onnodig en kan net zo goed weg, maar ik ben bang dat deze toch ergens nodig is, sorry voor deze, zal nooit meer gebeuren
public static class SplitJsonArray
{
    
    public static List<string> SplitJson(string response)
    {
        List<string> results = new List<string>();
        response = response.Trim(']');
        response = response.Trim('[');
        Debug.Log("Response: " + response);
        string[] worlds = response.Split('}');
        foreach (string s in worlds)
        {
            string trimmed = s.Trim(',');
            if(s != string.Empty)
            {
                results.Add(trimmed + "}");
            }
        }
        foreach (string s in results)
        {
            Debug.Log("Worlds: " + s);
        }
        return results;
    }
}
