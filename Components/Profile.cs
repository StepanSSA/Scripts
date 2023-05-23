using TMPro;
using UnityEngine;

public class Profile : MonoBehaviour
{
    [SerializeField]
    private TMP_Text NameField;
    [SerializeField]
    private TMP_Text LastnameField;
    [SerializeField]
    private TMP_Text BirthDateField;
    [SerializeField]
    private TMP_Text EmailField;

    public void FillProfile(UserModel user)
    {
        if(user == null) 
            return;

        NameField.text += user.Name;
        LastnameField.text += user.Lastname;
        BirthDateField.text += user.BirthDate;
        EmailField.text += user.Email;
    }
}
