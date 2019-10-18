using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

[System.Serializable]
public struct UserInfo
{
    public string userId;
    public string userPassword;
    public string userEmail;
    public int userAge;
}

public class AccountManager : MonoBehaviour
{
    [SerializeField] InputField userId;
    [SerializeField] InputField userPassword;
    [SerializeField] GYInputField userEmail;
    [SerializeField] InputField userAge;

    private void Start()
    {
        userAge.onValidateInput += GYValidate;
    }

    char GYValidate(string str, int val, char chr)
    {
        string allText = str + chr;

        Regex regex = new Regex(@"^\d{1,3}$");

        if (regex.IsMatch(allText))
        {
            return chr;
        }
        return '\0';
    }

    public void Save()
    {
        if (!IsCorrectEmail(userEmail.text))
        {
            userEmail.Incorrect();
            return;
        }

        UserInfo userInfo;
        userInfo.userId = userId.text;
        userInfo.userPassword = userPassword.text;
        userInfo.userEmail = userEmail.text;
        userInfo.userAge = int.Parse(userAge.text);

        BinaryFormatter bf = new BinaryFormatter();

        string path = GetFilePath("account.dat");
        FileStream fs = File.Create(path);

        bf.Serialize(fs, userInfo);
        fs.Close();
    }

    string GetFilePath(string fileName)
    {
        string path = string.Format("{0}/{1}", 
            Application.persistentDataPath, fileName);
        return path;
    }

    bool IsCorrectEmail(string email)
    {
        Regex regex = new Regex(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+$");

        if (regex.IsMatch(email))
        {
            return true;
        }
        return false;
    }
}
