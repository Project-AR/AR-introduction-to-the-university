using UnityEngine;

public class ManagerUI : MonoBehaviour
{

    [SerializeField] private GameObject LoginPanel;
    [SerializeField] private GameObject OnBoardingPanel;
    [SerializeField] private GameObject RegistrationPanel;
    [SerializeField] private GameObject EmailConfirmationPanel;
    [Space]
    [SerializeField] private GameObject NavigationgPanel;
    [SerializeField] private GameObject ProfilePanel;
    [SerializeField] private GameObject ReitingPanel;
    [SerializeField] private GameObject TasksPanel;
    [SerializeField] private GameObject CollectionPanel;

    [SerializeField] private GameObject AR;
    [SerializeField] private GameObject ARTracking;

    private bool isFirstLaunch = true;
    private bool isArActive = false;
    private bool confirmRegustration = false;
    
    private void Start()
    {
        if (isFirstLaunch)
        {
            isFirstLaunch = !isFirstLaunch;
            OnBoardingPanel.SetActive(true);
        }
        else
        {
            ShowLoginPanel();
        }
    }
    public void ShowLoginPanel()
    {
        RegistrationPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }
    public void ShowRegistrationPanel()
    {
        OnBoardingPanel.SetActive(false);
        LoginPanel.SetActive(false);
        RegistrationPanel.SetActive(true);
    }
    public void ShowEmailConfirmationPanel(bool confirm)
    {
        confirmRegustration = confirm;
        RegistrationPanel.SetActive(false);
        EmailConfirmationPanel.SetActive(true);
        EmailConfirmationPanel.GetComponent<EmailConfirmUIScript>().setConfirmationResult(confirm);
    }
    public void EmailConfirmationResult()
    {
        if (confirmRegustration) ShowMain();
        else ShowRegistrationPanel();
    }

    public void ActivateAR(bool isActivate)
    {
        AR.SetActive(isActivate);
        ARTracking.SetActive(isActivate);
    }

    public void ShowMain()
    {
        EmailConfirmationPanel.SetActive(false);

        isArActive = false;
        ActivateAR(isArActive);

        NavigationgPanel.SetActive(true);
        ProfilePanel.SetActive(true);
    }
    public void ShowARPanel()
    {
        isArActive = true;
        ActivateAR(isArActive);
        ProfilePanel.SetActive(false);
        ReitingPanel.SetActive(false);
        TasksPanel.SetActive(false);
        CollectionPanel.SetActive(false);
    }
    public void ShowProfilePanel()
    {
        isArActive = false;
        ActivateAR(isArActive);
        ProfilePanel.SetActive(true);
        ReitingPanel.SetActive(false);
        TasksPanel.SetActive(false);
        CollectionPanel.SetActive(false);
    }
    public void ShowReitingPanel()
    {
        isArActive = false;
        ActivateAR(isArActive);
        ProfilePanel.SetActive(false);
        ReitingPanel.SetActive(true);
        TasksPanel.SetActive(false);
        CollectionPanel.SetActive(false);
    }
    public void ShowTasksPanel()
    {
        isArActive = false;
        ActivateAR(isArActive);
        ProfilePanel.SetActive(false);
        ReitingPanel.SetActive(false);
        TasksPanel.SetActive(true);
        CollectionPanel.SetActive(false);
    }
    public void ShowCollectionPanel()
    {
        isArActive = false;
        ActivateAR(isArActive);
        ProfilePanel.SetActive(false);
        ReitingPanel.SetActive(false);
        TasksPanel.SetActive(false);
        CollectionPanel.SetActive(true);
    }
}
