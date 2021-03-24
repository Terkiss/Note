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


        // ���ټ� ���� �ڷ�ƾ�� �Ϸ� �� ���°�?
        // true -> �������� �Ϸ�
        // false -> ������ 
        private bool potentialProcessorDone = true;

        // ���� ĳ���� �ε���
        private int current;
        private int tmprrIndex = 0 ; // �ӽ� �ε���

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

            // ������ ���̽����� �����͸� ���� �ɴϴ�.
            importData();
            
            // ��� �ؽ�Ʈ 
            goldText = GameObject.Find("haveCount").GetComponent<Text>();

            // ���ټ� ������ ����
            preePotentail = new PotenWindwos(_StatWIndow);
            newPotentail = new PotenWindwos(_NextStatWindow);

            // ĳ�� ǥ��
            toggleActive(info[current].name);

            // ���ټ� ������ ����
            potentialDataRestoration();
        }

        #endregion //MonoBehaviour


        #region Private Methods
        /// <summary>
        /// ���� sqllite ������ ���̽� ���� �����͸� ���� �ɴϴ�.
        /// 
        /// </summary>
        private void importData()
        {

            // chrinfo ���̺��� ĳ�� �� ���� ��������
            string sql = "select * from chr_info";

            SqliteDataReader dataReader = databaseHelper.sqlRunForResult(sql);

            // ĳ���� ���̵�
            List<string> chrID = new List<string>();
            // ĳ���� �̸� 
            List<string> chr_Name = new List<string>();

            while (dataReader.Read())
            {
                string chr_id = dataReader.GetString(1);

                // ĳ���� ���̵� ��Ģ�� ù 2�� ���ڰ� 01 /02 /03 ������� �������� ���� 
                int select = int.Parse(chr_id.Substring(0, 2));

                if (select == 1)
                {
                    //Debug.Log($"id:{dataReader.GetInt32(0)}, chr_id : {dataReader.GetString(1)}, chr_name : {dataReader.GetString(2)}, info : {dataReader.GetString(3)}");
                    // ĳ���� ���� ���̺��� ������ ���� ���� id  =  int, chr_id = string, char_Name = string, info = string
                    chrID.Add(dataReader.GetString(1));
                    chr_Name.Add(dataReader.GetString(2));
                }
            }

            for (int i = 0; i < chrID.Count; i++)
            {
                // ���ټ� ���̺��� ĳ���� ���̵�� �����͸� ������ 
                sql = "select * from potentail where chr_id ='" + chrID[i] + "'";

                dataReader = databaseHelper.sqlRunForResult(sql);

                while (dataReader.Read())
                {

                    // ĳ���� ���� �� �����ϴ� Ŭ���� �� ���� 
                    CharacterInfo character = new CharacterInfo();

                    // ���� ��
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
        /// ĳ���� ������Ʈ�� Ȱ��ȭ ��Ȱ��ȭ ���ݴϴ�.
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
                    //Debug.Log($"�O�� �̸� {name} ��Ī{findObj.name}");
                    findObj.gameObject.SetActive(true);
                }
                else
                {
                    findObj.gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// ���ټ� ������ ���� �޼���
        /// ���ټ� �����͸� ���� ���ݴϴ�.
        /// ������ ������ ���̽����� �о� ���°��� �ƴ� ������ ĳ���ص� �����͸� �����ٰ� ���� �մϴ�.
        /// </summary>
        private void potentialDataRestoration()
        {
            preePotentail.setCharacterData(info[current]);

            preePotentail.Build();
        }

        // ��� �� �����ɴϴ�
        private int getGoldValue()
        {
            string gValue = goldText.text.Replace("x", ""); // x����
            gValue = gValue.Replace(" ", ""); // ���� ����
            gValue = gValue.Replace("G", ""); // g ���� 

            int gold = int.Parse(gValue);

            return gold;
        }

        // ��带 ���� �մϴ�
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
        /// ���ټ� �ɷ�ġ�� �����Ͽ� UI�� �ѷ��ݴϴ�.
        /// </summary>
        public void setPotentail()
        {

            if (!newPotentail.ifNotExecuted())
            {
                Debug.LogError("Accep ��ư�̳� cancle ��ư�� ��������");
                return;
            }

            // ��� �� �����ɴϴ�.
            int gold = getGoldValue();

            if (potentialProcessorDone == true)
            {
                // ������ ���������� �Ϸ�� ���¶�� ���ټ� ���� �ڷ�ƾ�� ���� 
                StartCoroutine(potentialEffectProcessor(gold));
            }
        }


        private IEnumerator potentialEffectProcessor(int gold)
        {
            potentialProcessorDone = false;
            gold -= 20;
            setGoldValue(gold);

            int[] randomPotentail = new int[6];
            // ���ο� ���� �ɷ�ġ�� ������

            for (int i = 0; i < randomPotentail.Length; i++)
            {
                randomPotentail[i] = Random.Range(1, 11);  
            }

            // UI�� ���� ���� ���ټ� �ɷ�ġ�� ������ 
            CharacterInfo newPotenValue = new CharacterInfo();
            newPotenValue.setValueForFloat(randomPotentail[0], randomPotentail[1],
                                           randomPotentail[2], randomPotentail[3],
                                           randomPotentail[4], randomPotentail[5]);

            newPotentail.setCharacterData(newPotenValue);

            float prePotenAverage = preePotentail.getAverage();
            float newPotenAverage = newPotentail.getAverage();

            // �ʿ��� ������Ʈ�� �Ҵ� 
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


        // ���ټ��� Ȯ�� �մϴ� .
        public void acceptPotentail()
        {
            if (newPotentail.ifNotExecuted() || potentialProcessorDone == false)
            {
                Debug.LogError("���� Ʈ���� ���ּ���");
                return;
            }

            preePotentail.setCharacterData(newPotentail.getCharacterData());

            // Ȯ�� ����Ʈ�� ���� ���� ���� 
            info[current].damage = newPotentail.getCharacterData().damage;
            info[current].abilityPower = newPotentail.getCharacterData().abilityPower;
            info[current].armor = newPotentail.getCharacterData().armor;
            info[current].magicResistance = newPotentail.getCharacterData().magicResistance;
            info[current].health = newPotentail.getCharacterData().health;
            info[current].criticalChance = newPotentail.getCharacterData().criticalChance;

            preePotentail.Build();

            newPotentail.zeroFill();

            // ������ ���̽� �ݿ� 
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

        // ���ټ��� ��� �մϴ�.
        public void revortPotentail()
        {
            if (potentialProcessorDone == false)
            {
                Debug.Log("���� �������ϴ�.");
                return;
            }
            newPotentail.zeroFill();
        }

        // ���� ĳ���ͷ� �ٲ� �ݴϴ�.
        public void changeNextCharacterSStats()
        {
            if (potentialProcessorDone == false)
            {
                Debug.Log("���� �������ϴ�.");
                return;
            }

            revortPotentail();
            tmprrIndex++;
            current = tmprrIndex % info.Count;

            // ĳ�� ǥ��
            toggleActive(info[current].name);

            // ���ټ� ������ ����
            potentialDataRestoration();

        }

        // ���� ĳ���ͷ� �ٲ� �ݴϴ�
        public void changedPreviousCharacterStats()
        {
            if (potentialProcessorDone == false)
            {
                Debug.Log("���� �������ϴ�.");
                return;
            }
            revortPotentail();
            tmprrIndex--;
            if (tmprrIndex < 0)
            {

                tmprrIndex = info.Count - 1;

            }

            current = tmprrIndex % info.Count;

            // ĳ�� ǥ��
            toggleActive(info[current].name);

            // ���ټ� ������ ����
            potentialDataRestoration();
        }

        #endregion
    }

    #region Heler class
    // ���ټ� �����͸� ������ �ִ� ������ Ŭ���� 
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

        // float �������� �޾Ƽ� string ���� ��ȯ�� ��Ʈ ���� 
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


