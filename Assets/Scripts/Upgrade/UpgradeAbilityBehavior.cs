using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeAbilityBehavior : MonoBehaviour, IUpgrade
{
    private Player player;

    [SerializeField] private TextMeshProUGUI upgradeTitleText; //업그레이드
    [SerializeField] private TextMeshProUGUI levelText; //레벨
    [SerializeField] private TextMeshProUGUI costText; //비용
    public Abliity ability;

    private void Start()
    {
        Debug.Log("ability.Cost : "+ability.Cost);
        //스킬 포인트 텍스트에 넣어주기
        levelText.text = ability.Level.ToString();
        //스킬 포인트 텍스트에 넣어주기
        costText.text = ability.Cost.ToString();
        player = PlayerController.Instance.player;
    }

    public void OnUpgradeButtonClick()
    {
        if (!ability.IsMaxLevel() && player.Coins - ability.Cost >= 0)
        {
            //레벨 / cost 올리기
            ability.UpLevel();
            //돈 쓰기
            player.SetCoins(ability.Cost, "Down");
            //업그레이드 비용 증가
            ability.SetCost();
            //업그레이드 ui 업데이트
            UpdateUI();


            switch (ability.UpgradeTitle)
            {
                case "캐릭터 이동 속도":
                    PlayerController.Instance.speed += 0.1f;
                    break;

                case "캐릭터 점프 속도":
                    PlayerController.Instance.jumpSpeed += 0.1f;
                    break;

                case "캐릭터 무적 시간":
                    PlayerController.Instance.invincibilityTime += 0.1f;
                    break;

                case "기본 공격력":
                    PlayerController.Instance.weapon.cutDamage += 1f;
                    Debug.Log(PlayerController.Instance.weapon.cutDamage);
                    Debug.Log("베기 스킬 업그레이드");
                    break;

                default:
                    break;
            } 
        }
        else
        {
            UIController.Instance.SetActiveNoticePopUp();
            UIController.Instance.noticeText.text = "코인이 부족합니다.";
            Debug.Log("코인 부족");
        }
    }
   

    private void UpdateUI()
    {
        levelText.text = ability.Level.ToString();
        costText.text = ability.Cost.ToString();    
    }

}
