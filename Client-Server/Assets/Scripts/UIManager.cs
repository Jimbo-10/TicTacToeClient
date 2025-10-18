using UnityEngine;

public class UIManager : MonoBehaviour
{
    private NetworkClient client;

    [SerializeField]
    GameObject mainMenu;

    [SerializeField]
    GameObject createAccount;

    [SerializeField]
    GameObject login;

    [SerializeField]
    GameObject loggedIn;

    [SerializeField]
    GameObject lobbyRoom;

    [SerializeField]
    GameObject waitingRoom;

    [SerializeField]
    GameObject playRoom;

    public TMPro.TMP_InputField usernameInput;
    public TMPro.TMP_InputField passwordInput;
    public TMPro.TMP_InputField roomInput;

    public TMPro.TMP_Text feedbackText;

    private States currentState;

    void Start()
    {
        SetState(States.MainMenu);
    }

    public void SetState(States newState)
    {
        currentState = newState;

        mainMenu.SetActive(currentState == States.MainMenu);
        login.SetActive(currentState == States.Login);
        createAccount.SetActive(currentState == States.CreateAccount);
    }

    public void LoginButton()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        client?.Login(username, password);

        login.SetActive(true);
        createAccount.SetActive(false);
        mainMenu.SetActive(false);
        ClearFeedback();
    }

    public void CreateAccountButton()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowFeedback("Username or password cannot be empty!");
            return;
        }

        client?.CreateAccount(username, password);

        login.SetActive(false);
        createAccount.SetActive(true);
        mainMenu.SetActive(false);
        lobbyRoom.SetActive(false);
        waitingRoom.SetActive(false);
        playRoom.SetActive(false);
        ClearFeedback();
    }

    public void ShowFeedback(string message)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.gameObject.SetActive(true);
        }
    }

    // Clear feedback
    public void ClearFeedback()
    {
        if (feedbackText != null)
        {
            feedbackText.text = "";
            feedbackText.gameObject.SetActive(false);
        }
    }

    public void ShowLobby()
    {
        login.SetActive(false);
        createAccount.SetActive(false);
        mainMenu.SetActive(false);
        lobbyRoom.SetActive(true);
        waitingRoom.SetActive(false);
        playRoom.SetActive(false);
    }

    public void ShowWaitingScreen()
    {
        login.SetActive(false);
        createAccount.SetActive(false);
        mainMenu.SetActive(false);
        lobbyRoom.SetActive(false);
        waitingRoom.SetActive(true);
        playRoom.SetActive(false);
    }

    public void ShowPlayScreen()
    {
        login.SetActive(false);
        createAccount.SetActive(false);
        mainMenu.SetActive(false);
        lobbyRoom.SetActive(false);
        waitingRoom.SetActive(false);
        playRoom.SetActive(true);
    }
}
