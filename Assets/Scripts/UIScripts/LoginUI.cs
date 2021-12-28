using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VectorGraphics;
using TMPro;

public class LoginUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField loginInput;
    [SerializeField] private TMP_InputField passwordInput;
    [Space]
    [SerializeField] private Text errorLabel;
    [SerializeField] private Text loginButtonText;
    [Space]
    [SerializeField] private Sprite hidePassButton_Open;
    [SerializeField] private Sprite hidePassButton_Hide;
    [SerializeField] private Sprite loginButton_Enable;
    [SerializeField] private Sprite loginButton_Disable;
    [Space]
    [SerializeField] private SVGImage hidePassButton;
    [SerializeField] private SVGImage loginButton;
    [Space]
    [SerializeField] private Color errorLabelTextColor;
    [SerializeField] private Color infoLabelTextColor;
    [SerializeField] private Color loginButtonTextColor_Enable;
    [SerializeField] private Color loginButtonTextColor_Disable;
    [Space]

    private bool isPassHide = true;
    private bool isLoginButtonEnable = false;

    public UnityEvent LoginConfirmData;
    public void ShowPassButton_Click()
    {
        if (isPassHide)
        {
            passwordInput.contentType = TMP_InputField.ContentType.Name;
            hidePassButton.sprite = hidePassButton_Open;

        }
        else
        {
            passwordInput.contentType = TMP_InputField.ContentType.Password;
            hidePassButton.sprite = hidePassButton_Hide;
        }
        isPassHide = !isPassHide;
        passwordInput.ForceLabelUpdate();
    }
    public void CheckFieldsState()
    {
        if (loginInput.text.Length > 0 && passwordInput.text.Length > 0)
        {
            isLoginButtonEnable = true;
            loginButton.sprite = loginButton_Enable;
            loginButtonText.color = loginButtonTextColor_Enable;
        }
        else
        {
            isLoginButtonEnable = false;
            loginButton.sprite = loginButton_Disable;
            loginButtonText.color = loginButtonTextColor_Disable;
        }
    }
    public void Verification()
    {
        if (isLoginButtonEnable && LoginVerification(loginInput.text) && PasswordVerification(passwordInput.text)) LoginConfirmData?.Invoke();

    }
    private bool LoginVerification(string login)
    {
        if (login.Length < 4)
        {
            errorLabel.gameObject.SetActive(true);
            errorLabel.color = errorLabelTextColor;
            errorLabel.fontStyle = FontStyle.Normal;
            errorLabel.text = "Некорректные логин или пароль";
            return false;
        }

        foreach (var a in login)
        {
            if (a == ' ' || a == '/')
            {
                errorLabel.gameObject.SetActive(true);
                errorLabel.color = errorLabelTextColor;
                errorLabel.fontStyle = FontStyle.Normal;
                errorLabel.text = "Некорректные логин или пароль";
                return false;
            }
        }
        return true;
    }
    private bool PasswordVerification(string pass)
    {
        if (pass.Length < 6)
        {
            errorLabel.gameObject.SetActive(true);
            errorLabel.color = errorLabelTextColor;
            errorLabel.fontStyle = FontStyle.Normal;
            errorLabel.text = "Некорректные логин или пароль";
            return false;
        }
        foreach (char a in pass)
        {
            if (a == ' ' || a == '/')
            {
                errorLabel.gameObject.SetActive(true);
                errorLabel.color = errorLabelTextColor;
                errorLabel.fontStyle = FontStyle.Normal;
                errorLabel.text = "Некорректные логин или пароль";
                return false;
            }
        }
        return true;
    }

    public void LoginFieldChange()
    {
        errorLabel.color = infoLabelTextColor;
        errorLabel.fontStyle = FontStyle.Bold;
        errorLabel.text = "Введите свои данные для входа";
        errorLabel.gameObject.SetActive(false);
        CheckFieldsState();
    }
    public void PasswordFieldChange()
    {
        errorLabel.color = infoLabelTextColor;
        errorLabel.fontStyle = FontStyle.Bold;
        errorLabel.text = "Введите свои данные для входа";
        errorLabel.gameObject.SetActive(false);
        CheckFieldsState();
    }
    public void ShowNotFoundInputLoginData()
    {
        errorLabel.gameObject.SetActive(true);
        errorLabel.color = errorLabelTextColor;
        errorLabel.fontStyle = FontStyle.Normal;
        errorLabel.text = "Неверные логин или пароль";
        loginInput.text = "";
        passwordInput.text = "";
    }
}
