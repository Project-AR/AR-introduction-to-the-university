using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VectorGraphics;
using TMPro;

public class RegistrationUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField loginInput;
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;
    [Space]
    [SerializeField] private Text loginErrorLabel;
    [SerializeField] private Text emailErrorLabel;
    [SerializeField] private Text passwordErrorLabel;
    [SerializeField] private Text regButtonText;
    [Space]
    [SerializeField] private Sprite hidePassButton_Open;
    [SerializeField] private Sprite hidePassButton_Hide;
    [SerializeField] private Sprite radioButton_On;
    [SerializeField] private Sprite radioButton_Off;
    [SerializeField] private Sprite regButton_Enable;
    [SerializeField] private Sprite regButton_Disable;
    [Space]
    [SerializeField] private Color regButtonTextColor_Enable;
    [SerializeField] private Color regButtonTextColor_Disable;
    [Space]
    [SerializeField] private SVGImage hidePassButton;
    [SerializeField] private SVGImage radioButton;
    [SerializeField] private SVGImage regButton;

    private bool isPassHide = true;
    private bool isApprove = false;
    private bool isRegButtonEnable = false;

    public UnityEvent RegistrateConfirmData;

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
    public void AcceptUserAgreementButton_Click()
    {
        isApprove = !isApprove;
        radioButton.sprite = isApprove ? radioButton_On : radioButton_Off;
        CheckFieldsState();
    }
    public void CheckFieldsState()
    {
        if (loginInput.text.Length > 0 && emailInput.text.Length > 0 && passwordInput.text.Length > 0 && isApprove)
        {
            isRegButtonEnable = true;
            regButton.sprite = regButton_Enable;
            regButtonText.color = regButtonTextColor_Enable;
        }
        else
        {
            isRegButtonEnable = false;
            regButton.sprite = regButton_Disable;
            regButtonText.color = regButtonTextColor_Disable;
        }
    }

    public void Verification()
    {
        if (isRegButtonEnable)
        {
            string login = loginInput.text;
            string email = emailInput.text;
            string pass = passwordInput.text;
            if (LoginVerification(login) && EmailVerification(email)
                && PasswordVerification(pass)
                && isApprove) RegistrateConfirmData?.Invoke();
        }

    }
    private bool LoginVerification(string login)
    {
        if (login.Length < 4)
        {
            loginErrorLabel.gameObject.SetActive(true);
            loginErrorLabel.text = "Слишком короткий логин";
            return false;
        }

        foreach (var a in login)
        {
            if (a == ' ' || a == '/')
            {
                loginErrorLabel.gameObject.SetActive(true);
                loginErrorLabel.text = "Некорректные символы в логине";
                return false;
            }
        }
        return true;
    }
    private bool EmailVerification(string email)
    {
        if (email.Length <= 4)
        {
            emailErrorLabel.gameObject.SetActive(true);
            emailErrorLabel.text = "Некорректная электронная почта";
            return false;
        }
        bool dog = false; bool dot = false;
        foreach (var a in email)
        {
            if (a == ' ' || a == '/')
            {
                emailErrorLabel.gameObject.SetActive(true);
                emailErrorLabel.text = "Некорректная электронная почта";
                return false;
            }
            if (a == '@') dog = true;
            if (a == '.') dot = true;
        }
        if (dog && dot)
        {
            return true;
        }
        else
        {
            emailErrorLabel.gameObject.SetActive(true);
            emailErrorLabel.text = "Некорректная электронная почта";
            return false;
        }
    }
    private bool PasswordVerification(string pass)
    {
        if (pass.Length < 6)
        {
            passwordErrorLabel.gameObject.SetActive(true);
            passwordErrorLabel.text = "Слишком короткий логин";
            return false;
        }
        foreach (char a in pass)
        {
            if (a == ' ' || a == '/')
            {
                passwordErrorLabel.gameObject.SetActive(true);
                passwordErrorLabel.text = "Некорректные символы в пароле";
                return false;
            }
        }
        return true;
    }

    public void LoginFieldChange()
    {
        loginErrorLabel.gameObject.SetActive(false);
        CheckFieldsState();
    }
    public void EmailFieldChange()
    {
        emailErrorLabel.gameObject.SetActive(false);
        CheckFieldsState();
    }
    public void PasswordFieldChange()
    {
        passwordErrorLabel.gameObject.SetActive(false);
        CheckFieldsState();
    }
}
