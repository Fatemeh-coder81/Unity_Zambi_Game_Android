using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class Game_Maneger : MonoBehaviour
{

    [Header("Wepen UI : \n")]

    [SerializeField] private Wepen_Data_Base Wepen_Data_Base;

    public GameObject Wepen_Buttens_Conteiner;

    public GameObject Wepen_Butten_Prifab;
   

    [Header("Mony : \n")]

    [SerializeField] private TextMeshProUGUI Mony_Text;


    [SerializeField] private Bank Bank;

    public bool Menu_is_Open = false;

    public Animator Wepen_Menu;

    [Header("Casel Life UI : \n")]

    public Image Casel_Life_line;

    
    void Start()
    {
        Updata_Ui_Wepen_List();
        UpdateUI();
    }

    void Update()
    {

    }


    #region Wepen_List_Scroll

    public ScrollRect scrollRect;
    public float scrollStep = 0.1f; // مقدار حرکت در هر بار فشار دادن دکمه

    public void ScrollLeft()
    {
        float newHorizontalPosition = Mathf.Clamp01(scrollRect.horizontalNormalizedPosition - scrollStep);
        scrollRect.horizontalNormalizedPosition = newHorizontalPosition;
    }

    public void ScrollRight()
    {
        float newHorizontalPosition = Mathf.Clamp01(scrollRect.horizontalNormalizedPosition + scrollStep);
        scrollRect.horizontalNormalizedPosition = newHorizontalPosition;
    }

    #endregion


    #region Bank_UI

    public void DepositMoney(object data)
    {
        Bank.Deposit( (float)data, Mony_Text);   
    }

    public bool WithdrawMoney(float Ammount)
    {
       return Bank.Withdraw(Ammount, Mony_Text);
    }

    public void UpdateUI()
    {
        Mony_Text.text = Bank.Coin.ToString();

    }


    #endregion


    #region Wepen_Menu_Animation_Handel

    public void Handel_Wepen_Menu_Animation()
    {
        Menu_is_Open = !Menu_is_Open;
        Wepen_Menu.SetBool("Menu_Open", Menu_is_Open);

    }

    #endregion


    #region Updata_UI_Wepen_List

    public void Updata_Ui_Wepen_List()
    {
        for(int i = 0; i < Wepen_Data_Base.WeaponsList.Count; i++)
        {
            GameObject Butten = Instantiate(Wepen_Butten_Prifab, Wepen_Buttens_Conteiner.transform);

            Butten_Wepen_Controller bt =  Butten.GetComponent<Butten_Wepen_Controller>();

            bt.UI_OutPut.Wepen_Image.sprite = Wepen_Data_Base.WeaponsList[i].Wepen_Icon;

            bt.Wepen_Id = int.Parse(Wepen_Data_Base.WeaponsList[i].Wepen_Id);

            bt.UI_OutPut.Price_Text.text = Wepen_Data_Base.WeaponsList[i].weaponPrice.ToString();
       



        
        }
    }


    #endregion

    #region Casel_Ui_Handler

    public void Handel_Casel_Life_UI(object data)
    {
        Casel_Life_line.fillAmount = ((float)data)/1000;
    }


    #endregion



}
