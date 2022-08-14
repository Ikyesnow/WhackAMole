using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Diamantes : MonoBehaviour
{
    public TextMeshProUGUI enter;
    public TextMeshProUGUI exit;

    public string str = null;
    public char[] ini = null;
    public char[] end = null;

    public string diamonds = String.Empty;

    public void Cleaning()
    {
        str = enter.text;
        diamonds = String.Empty ;

        ini = (from c in str
               where char.Equals(c, '<')
               select c).ToArray();

        end = ((from c in str
                where char.Equals(c, '>')
                select c).ToArray());

        if (ini.Length <= end.Length && ini.Length != 0)
        {
            for (int i = 0; i < ini.Length; i++)
            {
                diamonds += ini[i].ToString();
                diamonds += end[i].ToString();
            }
        }
        else if (ini.Length > end.Length && end.Length != 0)
        {
            for (var i = 0; i < end.Length; i++)
            {
                diamonds += ini[i].ToString();
                diamonds += end[i].ToString();
            }
        }
        
        
        exit.text = diamonds;
    }
}
