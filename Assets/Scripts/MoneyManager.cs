using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

	public static MoneyManager current;

	[SerializeField]

	private Text moneyFiledText;

	[SerializeField]
	private int money;

	public int Money 
  	{
    	get { return money; }  
  	}

	private void UpdateMoneyFiled(){
		moneyFiledText.text = "Деньги:"+money+"$";
	}

	public bool CanSpend(int value){
		if(Mathf.Abs(value) <= money) return true;

		return false;
	}

	public void AddMoney(int cost){
		money += cost;
		UpdateMoneyFiled();
	}

	public void ReduceMoney(int value){
		money -= value;
		UpdateMoneyFiled();
	}

	void Awake () {
		current = this;
		UpdateMoneyFiled();
	}
	
}
