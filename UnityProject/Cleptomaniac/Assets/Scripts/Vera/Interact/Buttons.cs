using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
    public int count;
    public bool thousand;
    public bool hunderd;
    public bool tens;
    public bool finished;
    public OpenVault openVault;
    public Text number;

    public void b1()
    {
        if (finished == false)
        {
            if (thousand == true && hunderd == false && tens == false)
            {
                count *= 10;
                count += 1;
                hunderd = true;
                number.text = count.ToString();

            }
            else if (hunderd == true && tens == false)
            {
                count *= 10;
                count += 1;
                tens = true;
                number.text = count.ToString();
            }
            else if (tens == true)
            {
                count *= 10;
                count += 1;
                finished = true;
                Check();
                number.text = count.ToString();
            }
            else
            {
                count += 1;
                thousand = true;
                number.text = count.ToString();
            }
        }
    }
    public void b2()
    {
        if (finished == false)
        {
            if (thousand == true && hunderd == false && tens == false)
            {
                count *= 10;
                count += 2;
                hunderd = true;
                number.text = count.ToString();
            }
            else if (hunderd == true && tens == false)
            {
                count *= 10;
                count += 2;
                tens = true;
                number.text = count.ToString();
            }
            else if (tens == true)
            {
                count *= 10;
                count += 2;
                finished = true;
                Check();
                number.text = count.ToString();
            }
            else
            {
                count += 2;
                thousand = true;
                number.text = count.ToString();
            }
        }
    }
    public void b3()
    {
        if (finished == false)
        {
            if (thousand == true && hunderd == false && tens == false)
            {
                count *= 10;
                count += 3;
                hunderd = true;
                number.text = count.ToString();

            }
            else if (hunderd == true && tens == false)
            {
                count *= 10;
                count += 3;
                tens = true;
                number.text = count.ToString();
            }
            else if (tens == true)
            {
                count *= 10;
                count += 3;
                finished = true;
                Check();
                number.text = count.ToString();
            }
            else
            {
                count += 3;
                thousand = true;
                number.text = count.ToString();
            }
        }
    }
    public void b4()
    {
        if (finished == false)
        {
            if (thousand == true && hunderd == false && tens == false)
            {
                count *= 10;
                count += 4;
                hunderd = true;
                number.text = count.ToString();
            }
            else if (hunderd == true && tens == false)
            {
                count *= 10;
                count += 4;
                tens = true;
                number.text = count.ToString();
            }
            else if (tens == true)
            {
                count *= 10;
                count += 4;
                finished = true;
                Check();
                number.text = count.ToString();
            }
            else
            {
                count += 4;
                thousand = true;
                number.text = count.ToString();
            }
        }
    }
    public void b5()
    {
        if (finished == false)
        {
            if (thousand == true && hunderd == false && tens == false)
            {
                count *= 10;
                count += 5;
                hunderd = true;
                number.text = count.ToString();
            }
            else if (hunderd == true && tens == false)
            {
                count *= 10;
                count += 5;
                tens = true;
                number.text = count.ToString();
            }
            else if (tens == true)
            {
                count *= 10;
                count += 5;
                finished = true;
                Check();
                number.text = count.ToString();
            }
            else
            {
                count += 5;
                thousand = true;
                number.text = count.ToString();
            }
        }
    }
    public void b6()
    {
        if (finished == false)
        {
            if (thousand == true && hunderd == false && tens == false)
            {
                count *= 10;
                count += 6;
                hunderd = true;
                number.text = count.ToString();
            }
            else if (hunderd == true && tens == false)
            {
                count *= 10;
                count += 6;
                tens = true;
                number.text = count.ToString();
            }
            else if (tens == true)
            {
                count *= 10;
                count += 6;
                finished = true;
                Check();
                number.text = count.ToString();
            }
            else
            {
                count += 6;
                thousand = true;
                number.text = count.ToString();
            }
        }
    }
    public void b7()
    {
        if (finished == false)
        {
            if (thousand == true && hunderd == false && tens == false)
            {
                count *= 10;
                count += 7;
                hunderd = true;
                number.text = count.ToString();
            }
            else if (hunderd == true && tens == false)
            {
                count *= 10;
                count += 7;
                tens = true;
                number.text = count.ToString();
            }
            else if (tens == true)
            {
                count *= 10;
                count += 7;
                finished = true;
                Check();
                number.text = count.ToString();
            }
            else
            {
                count += 7;
                thousand = true;
                number.text = count.ToString();
            }
        }
    }
    public void b8()
    {
        if (finished == false)
        {
            if (thousand == true && hunderd == false && tens == false)
            {
                count *= 10;
                count += 8;
                hunderd = true;
                number.text = count.ToString();
            }
            else if (hunderd == true && tens == false)
            {
                count *= 10;
                count += 8;
                tens = true;
                number.text = count.ToString();
            }
            else if (tens == true)
            {
                count *= 10;
                count += 8;
                finished = true;
                Check();
                number.text = count.ToString();
            }
            else
            {
                count += 8;
                thousand = true;
                number.text = count.ToString();
            }
        }
    }
    public void b9()
    {
        if (finished == false)
        {
            if (thousand == true && hunderd == false && tens == false)
            {
                count *= 10;
                count += 9;
                hunderd = true;
                number.text = count.ToString();
            }
            else if (hunderd == true && tens == false)
            {
                count *= 10;
                count += 9;
                tens = true;
                number.text = count.ToString();
            }
            else if (tens == true)
            {
                count *= 10;
                count += 9;
                finished = true;
                Check();
                number.text = count.ToString();
            }
            else
            {
                count += 9;
                thousand = true;
                number.text = count.ToString();
            }
        }
    }
        public void b0()
    {
        if (finished == false)
        {
            if (thousand == true && hunderd == false && tens == false)
            {
                count *= 10;
                hunderd = true;
                number.text = count.ToString();

            }
            else if (hunderd == true && tens == false)
            {
                count *= 10;
                tens = true;
                number.text = count.ToString();
            }
            else if (tens == true)
            {
                count *= 10;
                finished = true;
                Check();
                number.text = count.ToString();
            }
            else
            {
                thousand = true;
                number.text = count.ToString();
            }
        }
    }
    public void Check()
    {
        openVault.codeInput = count;
        openVault.CodeCheck();
        StartCoroutine(textting());

    }
    public IEnumerator textting()
    {
        yield return new WaitForSeconds(2);
        thousand = false;
        hunderd = false;
        tens = false;
        finished = false;
        count = 0;
        number.text = count.ToString();
    }
}
