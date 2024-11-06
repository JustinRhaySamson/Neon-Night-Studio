using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrayExtensionMethods : MonoBehaviour
{
    public Array AddToArray(object o, Array a)
    {
        Array b = Array.CreateInstance(a.GetType().GetElementType(), a.Length + 1);
        a.CopyTo(b, 1);
        b.SetValue(o, 0);
        a = b;

        return a;

    }

    public Array AddToAtIndex(object o, Array a, int index)
    {
        Array b = Array.CreateInstance(a.GetType().GetElementType(), a.Length + 1);

        for (int i = 0; i < index; i++)
        {
            b.SetValue(a.GetValue(i), i);
        }
        for (int i = index + 1; i < b.Length; i++)
        {
            b.SetValue(a.GetValue(i - 1), i);
        }

        b.SetValue(o, index);
        a = b;

        return a;
    }
    public  Array Remove(object o, Array a)
    {
        if (a.GetType().GetElementType() == o.GetType())
        {
            if (a.Length == 0)
            {
                Debug.Log("array length already 0.");
                return a;
            }
            int occurrences = 0;
            for (int i = 0; i < a.Length; ++i)
            {
                if (a.GetValue(i).Equals(o))
                {
                    occurrences++;
                }
            }
            Array b = Array.CreateInstance(a.GetType().GetElementType(), a.Length - occurrences);
            int index = 0;
            for (int i = 0; i < a.Length; ++i)
            {
                if (!a.GetValue(i).Equals(o))
                {
                    b.SetValue(a.GetValue(i), index);
                    index++;

                }
            }
            a = b;
        }
        else
        {
            Debug.Log("Mismatched type passed as parameter for Array.Remove() -- (Type) "
                + a.GetType().GetElementType() + " != (Type) " + o.GetType());
        }
        return a;
    }
}
