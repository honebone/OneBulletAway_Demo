using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static string ColorStr(this string str, Color color)
    {
        return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + str + "</color>";
    }

    public static string ColorStr(this int value, Color color)
    {
        return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + value.ToString() + "</color>";
    }

    public static int ToInt(this float value) { return Mathf.FloorToInt(value); }
    public static int Limit(this int value, int max) { return Mathf.Min(value, max); }

    public static bool Dice(this float fPercent)
    {
        float dice = UnityEngine.Random.value * 100.0f;
        return dice <= fPercent;
    }

    public static bool Dice(this int chance)
    {
        int dice = Random.Range(0, 100);
        return dice < chance;
    }

    /// <summary>x~y-1�܂�</summary>
    public static int Range(this Vector2Int vector2)
    {
        return Random.Range(vector2.x, vector2.y);
    }

    public static int ChoiceWithWeight(this float[] weight)
    {
        float sum = 0;
        foreach (float c in weight)
        {
            sum += c;
        }
        float dice = Random.Range(0, sum);
        //Debug.Log(dice.ToString());
        for (int i = 0; i < weight.Length; i++)
        {
            if (dice < weight[i])
            {
                //Debug.Log(i.ToString());
                return i;
            }
            dice -= weight[i];
        }
        if (dice == sum) { return weight.Length - 1; }
        else
        {
            Debug.Log("error");
            return -1;
        }
    }
    public static int ChoiceWithWeight(this List<float> weight)
    {
        float sum = 0;
        foreach (float c in weight)
        {
            sum += c;
        }
        float dice = Random.Range(0, sum);
        //Debug.Log(dice.ToString());
        for (int i = 0; i < weight.Count; i++)
        {
            if (dice < weight[i])
            {
                //Debug.Log(i.ToString());
                return i;
            }
            dice -= weight[i];
        }
        if (dice == sum) { return weight.Count - 1; }
        else
        {
            Debug.Log("error");
            return -1;
        }
    }
    public static int ChoiceWithWeight(this List<int> weight)
    {
        float sum = 0;
        foreach (float c in weight)
        {
            sum += c;
        }
        float dice = Random.Range(0, sum);
        //Debug.Log(dice.ToString());
        for (int i = 0; i < weight.Count; i++)
        {
            if (dice < weight[i])
            {
                //Debug.Log(i.ToString());
                return i;
            }
            dice -= weight[i];
        }
        if (dice == sum) { return weight.Count - 1; }
        else
        {
            Debug.Log("error");
            return -1;
        }
    }
    /// <summary>0~length-1�܂ł̗���</summary>
    public static int RandIndex(this int length)
    {
        return Random.Range(0, length);
    }

    public static string GetValueWithSign(this float value)
    {
        if (value >= 0) { return "+" + value.ToString(); }
        else { return value.ToString(); }
    }
    public static string GetValueWithSign(this int value)
    {
        if (value >= 0) { return "+" + value.ToString(); }
        else { return value.ToString(); }
    }

    public static string Evaluate(this int value, bool invertEvaluation = false)
    {
        Color c = (value == 0) ? Color.gray : (value < 0 == invertEvaluation) ? Color.green : Color.red;
        if (value >= 0) { return ("+" + value.ToString()).ColorStr(c); }
        else { return value.ColorStr(c); }
    }

    public static string Evaluate(this float value, bool invertEvaluation = false)
    {
        Color c = (value == 0) ? Color.gray : (value < 0 == invertEvaluation) ? Color.green : Color.red;
        if (value >= 0) { return ("+" + value.ToString("0.##")).ColorStr(c); }
        else { return value.ToString("0.##").ColorStr(c); }
    }

    public static float GetPercent(this int value, int max)
    {
        return value * 100f / max;
    }

    public static int Sum(this List<int> list)
    {
        int sum = 0;
        foreach (int f in list)
        {
            sum += f;
        }
        return sum;
    }
    public static float Sum(this List<float> list)
    {
        float sum = 0;
        foreach (float f in list)
        {
            sum += f;
        }
        return sum;
    }

    /// <summary>�d���Ȃ���List�ǉ�</summary>
    public static void AddRangeWithNoOverlap<T>(this List<T> list, List<T> add)
    {
        foreach (T t in add)
        {
            if (!list.Contains(t)) { list.Add(t); }
        }
    }

    /// <summary>�d�����Ă���̂̂ݕԂ�</summary>
    public static List<T> AND<T>(this List<T> list1, List<T> list2)
    {
        List<T> list = new List<T>();
        foreach (T t in list2)
        {
            if (list1.Contains(t)) { list.Add(t); }
        }

        return list;
    }

    public static void RemoveList<T>(this List<T> list, List<T> remove)
    {
        foreach (T t in remove)
        {
            if (list.Contains(t)) { list.Remove(t); }
        }
    }

    /// <summary>�d���Ȃ��Ŏw�肳�ꂽ���̔z��������_���Ɏ擾�@�v�f��<=�w����̎��̓��X�g�S�̂�Ԃ�</summary>
    public static List<T> Sample<T>(this List<T> list, int amount)
    {
        if (list.Count <= amount) { return new List<T>(list); }

        List<T> pool = new List<T>(list);
        List<T> sample = new List<T>();
        int index;
        for (int i = 0; i < amount; i++)
        {
            index = pool.Count.RandIndex();
            sample.Add(pool[index]);
            pool.RemoveAt(index);
        }

        return sample;
    }

    public static T Choice<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static List<T> Shuffle<T>(this List<T> list)
    {
        List<T> shuffle = new List<T>(list);
        for (int i = shuffle.Count; i > 1; i--)
        {
            int k = Random.Range(0, i);
            T value = shuffle[k];
            shuffle[k] = shuffle[i - 1];
            shuffle[i - 1] = value;
        }

        return shuffle;
    }
}
