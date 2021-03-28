using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.Networking;
using System.Text;
using COM.COLDBLAZE.BATTLER.PLUG.SQLITEDB;

namespace COM.COLDBLAZE.BATTLER.UI.POTENTAIL
{
    public class PotentailReset : MonoBehaviour
    {
        #region public

        public GameObject _StatWIndow;
        public GameObject _NextStatWindow;

        public GameObject rootPlayer;

        #endregion
        

        #region private

        DatabaseHelper databaseHelper;

        List<CharacterInfo> info = new List<CharacterInfo>();


        // 포텐셜 설정 코루틴이 완료 되 었는가?
        // true -> 성공적인 완료
        // false -> 실행중 
        private bool potentialProcessorDone = true;

        // 현재 캐릭터 인덱스
        private int current;
        private int tmprrIndex = 0 ; // 임시 인덱스

        private PotenWindwos preePotentail;
        private PotenWindwos newPotentail;

        private Text goldText;
        private int gold;
        #endregion


        #region MonoBehaviour
        // Start is called before the first frame update
        void Start()
        {
            databaseHelper = DatabaseHelper._Instance;

            // 데이터 베이스에서 데이터를 꺼내 옵니다.
            importData();
            
            // 골드 텍스트 
            goldText = GameObject.Find("haveCount").GetComponent<Text>();

            // 포텐셜 윈도우 생성
            preePotentail = new PotenWindwos(_StatWIndow);
            newPotentail = new PotenWindwos(_NextStatWindow);

            // 캐릭 표현
            toggleActive(info[current].name);

            // 포텐셜 데이터 복구
            potentialDataRestoration();
        }

        #endregion //MonoBehaviour


        #region Private Methods
        /// <summary>
        /// 내부 sqllite 데이터 베이스 에서 데이터를 가져 옵니다.
        /// 
        /// </summary>
        private void importData()
        {

            // chrinfo 테이블에서 캐릭 터 정보 가져오기
            string sql = "select * from chr_info";

            SqliteDataReader dataReader = databaseHelper.sqlRunForResult(sql);

            // 캐릭터 아이디
            List<string> chrID = new List<string>();
            // 캐릭터 이름 
            List<string> chr_Name = new List<string>();

            while (dataReader.Read())
            {
                string chr_id = dataReader.GetString(1);

                // 캐릭터 아이디 규칙은 첫 2개 문자가 01 /02 /03 등등으로 아이템을 구별 
                int select = int.Parse(chr_id.Substring(0, 2));

                if (select == 1)
                {
                    //Debug.Log($"id:{dataReader.GetInt32(0)}, chr_id : {dataReader.GetString(1)}, chr_name : {dataReader.GetString(2)}, info : {dataReader.GetString(3)}");
                    // 캐릭터 정보 테이블은 다음과 같은 구조 id  =  int, chr_id = string, char_Name = string, info = string
                    chrID.Add(dataReader.GetString(1));
                    chr_Name.Add(dataReader.GetString(2));
                }
            }

            for (int i = 0; i < chrID.Count; i++)
            {
                // 포텐셜 테이블에서 캐릭터 아이디로 데이터를 추출함 
                sql = "select * from potentail where chr_id ='" + chrID[i] + "'";

                dataReader = databaseHelper.sqlRunForResult(sql);

                while (dataReader.Read())
                {

                    // 캐릭터 정보 를 관리하는 클래스 를 생성 
                    CharacterInfo character = new CharacterInfo();

                    // 변수 셋
                    character.chr_id = chrID[i];
                    character.name = chr_Name[i];
                    character.damage = dataReader.GetString(2);
                    character.abilityPower = dataReader.GetString(3);
                    character.armor = dataReader.GetString(4);
                    character.magicResistance = dataReader.GetString(5);
                    character.health = dataReader.GetString(6);
                    character.criticalChance = dataReader.GetString(7);

                    info.Add(character);
                }
            }
        }

        /// <summary>
        /// 캐릭터 오브젝트를 활성화 비활성화 해줍니다.
        /// </summary>
        /// <param name="name"></param>
        private void toggleActive(string name)
        {
            int length = rootPlayer.transform.childCount;

            for (int i = 0; i < length; i++)
            {
                Transform findObj = rootPlayer.transform.GetChild(i);

                if (findObj.name.Equals(name))
                {
                    //Debug.Log($"찿는 이름 {name} 매칭{findObj.name}");
                    findObj.gameObject.SetActive(true);
                }
                else
                {
                    findObj.gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// 포텐셜 데이터 복원 메서드
        /// 포텐셜 데이터를 복원 해줍니다.
        /// 복원은 데이터 베이스에서 읽어 오는것이 아닌 이전에 캐싱해둔 데이터를 가져다가 복원 합니다.
        /// </summary>
        private void potentialDataRestoration()
        {
            preePotentail.setCharacterData(info[current]);

            preePotentail.Build();
        }

        // 골드 를 가져옵니다
        private int getGoldValue()
        {
            string gValue = goldText.text.Replace("x", ""); // x제거
            gValue = gValue.Replace(" ", ""); // 공백 제거
            gValue = gValue.Replace("G", ""); // g 제거 

            int gold = int.Parse(gValue);

            return gold;
        }

        // 골드를 설정 합니다
        private void setGoldValue(int value)
        {
            if (value >= 0)
            {
                goldText.text = "x " + value.ToString() + "G";
            }
        }
        #endregion


        #region Public Event Method

        /// <summary>
        /// 포텐셜 능력치를 생성하여 UI에 뿌려줍니다.
        /// </summary>
        public void setPotentail()
        {

            if (!newPotentail.ifNotExecuted())
            {
                Debug.LogError("Accep 버튼이나 cancle 버튼을 누르세요");
                return;
            }

            // 골드 를 가져옵니다.
            int gold = getGoldValue();

            if (potentialProcessorDone == true)
            {
                // 실행이 성공적으로 완료된 상태라면 포텐셜 설정 코루틴을 실행 
                StartCoroutine(potentialEffectProcessor(gold));
            }
        }


        private IEnumerator potentialEffectProcessor(int gold)
        {
            potentialProcessorDone = false;
            gold -= 20;
            setGoldValue(gold);

            int[] randomPotentail = new int[6];
            // 새로운 포텐 능력치를 구했음

            for (int i = 0; i < randomPotentail.Length; i++)
            {
                randomPotentail[i] = Random.Range(1, 11);  
            }

            // UI에 새로 뽑은 포텐셜 능력치를 보여줌 
            CharacterInfo newPotenValue = new CharacterInfo();
            newPotenValue.setValueForFloat(randomPotentail[0], randomPotentail[1],
                                           randomPotentail[2], randomPotentail[3],
                                           randomPotentail[4], randomPotentail[5]);

            newPotentail.setCharacterData(newPotenValue);

            float prePotenAverage = preePotentail.getAverage();
            float newPotenAverage = newPotentail.getAverage();

            // 필요한 오브젝트들 할당 
            GameObject obj = rootPlayer.transform.Find(info[current].name).gameObject;
            Animator animator = obj.GetComponent<Animator>();
            ParticleSystem particleSystem = GameObject.Find("GlowZoneBlue").GetComponent<ParticleSystem>();

            Debug.Log(prePotenAverage + "|||" + newPotenAverage);
            if (prePotenAverage < newPotenAverage)
            {
                animator.SetTrigger("Success");
                yield return new WaitForSeconds(0.3f);
                particleSystem.Play();

                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                int select = Random.Range(1, 2);

                animator.SetTrigger("Question" + select);
                yield return new WaitForSeconds(0.3f);
                particleSystem.Play();

                yield return new WaitForSeconds(1.5f);
            }
            newPotentail.Build();
            potentialProcessorDone = true;
        }


        // 포텐셜을 확정 합니다 .
        public void acceptPotentail()
        {
            if (newPotentail.ifNotExecuted() || potentialProcessorDone == false)
            {
                Debug.LogError("먼저 트라이 해주세요");
                return;
            }

            preePotentail.setCharacterData(newPotentail.getCharacterData());

            // 확정 리스트에 현제 상태 저장 
            info[current].damage = newPotentail.getCharacterData().damage;
            info[current].abilityPower = newPotentail.getCharacterData().abilityPower;
            info[current].armor = newPotentail.getCharacterData().armor;
            info[current].magicResistance = newPotentail.getCharacterData().magicResistance;
            info[current].health = newPotentail.getCharacterData().health;
            info[current].criticalChance = newPotentail.getCharacterData().criticalChance;

            preePotentail.Build();

            newPotentail.zeroFill();

            // 데이터 베이스 반영 
            string sql = "UPDATE potentail SET AttackDamage = '" + info[current].damage
                + "', AbilityPower = '" + info[current].abilityPower
                + "', Armor = '" + info[current].armor
                + "', MagicResistance = '" + info[current].magicResistance
                + "', Health = '" + info[current].health
                + "', CriticalRate = '" + info[current].criticalChance
                + "' WHERE chr_id = '" + info[current].chr_id + "'";

            Debug.Log("sql:: " + sql);
            databaseHelper.sqlRun(sql);
        }

        // 포텐셜을 취소 합니다.
        public void revortPotentail()
        {
            if (potentialProcessorDone == false)
            {
                Debug.Log("먼저 못누릅니다.");
                return;
            }
            newPotentail.zeroFill();
        }

        // 다음 캐릭터로 바꿔 줍니다.
        public void changeNextCharacterSStats()
        {
            if (potentialProcessorDone == false)
            {
                Debug.Log("먼저 못누릅니다.");
                return;
            }

            revortPotentail();
            tmprrIndex++;
            current = tmprrIndex % info.Count;

            // 캐릭 표현
            toggleActive(info[current].name);

            // 포텐셜 데이터 복구
            potentialDataRestoration();

        }

        // 이전 캐릭터로 바꿔 줍니다
        public void changedPreviousCharacterStats()
        {
            if (potentialProcessorDone == false)
            {
                Debug.Log("먼저 못누릅니다.");
                return;
            }
            revortPotentail();
            tmprrIndex--;
            if (tmprrIndex < 0)
            {

                tmprrIndex = info.Count - 1;

            }

            current = tmprrIndex % info.Count;

            // 캐릭 표현
            toggleActive(info[current].name);

            // 포텐셜 데이터 복구
            potentialDataRestoration();
        }

        #endregion
    }

    #region Heler class
    // 포텐셜 데이터를 가지고 있는 데이터 클래스 
    public class CharacterInfo
    {
        public string chr_id { get; set; }
        public string name { get; set; }
        public string damage { get; set; }
        public string abilityPower { get; set; }
        public string armor { get; set; }

        public string magicResistance { get; set; }
        public string health { get; set; }
        public string criticalChance { get; set; }

        public CharacterInfo(string name, string damage, string ailityPower, string armor, string health, string criticalChance)
        {
            this.name = name;
            this.damage = damage;
            this.abilityPower = ailityPower;
            this.armor = armor;
            this.health = health;
            this.criticalChance = criticalChance;
        }
        public CharacterInfo()
        {

        }

        // float 변수들을 받아서 string 으로 변환후 세트 해줌 
        public void setValueForFloat(float damage, float abilityPower, float armor, float magicResistance, float health, float criticalChance)
        {
            this.damage = damage.ToString();
            this.abilityPower = abilityPower.ToString();
            this.armor = armor.ToString();
            this.health = health.ToString();
            this.criticalChance = criticalChance.ToString();
            this.magicResistance = magicResistance.ToString();
        }
    }



    public class PotenWindwos
    {
        private GameObject rootObj;

        private Text potentailText;
        private Text averageText;

        private CharacterInfo info;

        public PotenWindwos(GameObject obj)
        {
            rootObj = obj;
            potentailText = obj.transform.Find("StatText2").GetComponent<Text>();

            averageText = obj.transform.Find("Average").GetComponent<Text>();

            Build();
        }
        
        public void setCharacterData(CharacterInfo info)
        {
            this.info = info;
        }
        public CharacterInfo getCharacterData()
        {
            return info;
        }
      
        public float getAverage()
        {
            int sum = (int)((int.Parse(info.damage) + int.Parse(info.abilityPower) + int.Parse(info.armor) + int.Parse(info.magicResistance) + int.Parse(info.health) + int.Parse(info.criticalChance)) / 6.0f * 10);
            float average = sum / 10.0f;

            return average;
        }
   
        public bool ifNotExecuted()
        {
            if (info == null ||int.Parse(info.damage) == 0 || int.Parse(info.abilityPower)  == 0 || int.Parse(info.armor) == 0 || int.Parse(info.magicResistance) == 0 || int.Parse(info.health) == 0 || int.Parse(info.criticalChance) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void zeroFill()
        {
            info.damage = "0";
            info.abilityPower = "0";
            info.armor = "0";
            info.magicResistance = "0";
            info.health = "0";
            info.criticalChance = "0";

            Build();
        }


        public void Build()
        {

            StringBuilder st = new StringBuilder();

            if (ifNotExecuted())
            {
                st.Append("");

                averageText.text = "";
            }
            else
            {
                st.Append("+");
                st.Append(info.damage);
                st.Append("\n");
                st.Append("+");
                st.Append(info.abilityPower);
                st.Append("\n");
                st.Append("+");
                st.Append(info.armor);
                st.Append("\n");
                st.Append("+");
                st.Append(info.magicResistance);
                st.Append("\n");
                st.Append("+");
                st.Append(info.health);
                st.Append("\n");
                st.Append("+");
                st.Append(info.health);
                
                averageText.text = "AVERAGE  " + getAverage();
            }
            potentailText.text = st.ToString();
        }
    }
    #endregion
}


