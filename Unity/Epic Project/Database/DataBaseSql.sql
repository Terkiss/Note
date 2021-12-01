CharacterNameTable
CREATE TABLE `charactername` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`chr_ID` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`chr_NAME` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`chr_INFO` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`chr_Type` VARCHAR(50) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=15
;



캐릭터 스텟 테이블
CREATE TABLE `characterstat` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`chrID` VARCHAR(20) NOT NULL COLLATE 'utf8mb4_general_ci',
	`damage` VARCHAR(20) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`defense` VARCHAR(20) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`mdamage` VARCHAR(20) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`mdefense` VARCHAR(20) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`criticalRate` VARCHAR(20) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`healthy` VARCHAR(20) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`forceLife` VARCHAR(20) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=16
;


캐릭터 공격 정보 테이블(임시)
CREATE TABLE `character_attack_info` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`chr_ID` VARCHAR(50) NOT NULL COLLATE 'utf8mb4_general_ci',
	`attackType` VARCHAR(50) NOT NULL COLLATE 'utf8mb4_general_ci',
	`attackDamage` VARCHAR(50) NOT NULL COLLATE 'utf8mb4_general_ci',
	`attaclDuration` VARCHAR(50) NOT NULL COLLATE 'utf8mb4_general_ci',
	`attackFX` VARCHAR(50) NOT NULL COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=29
;

캐릭터 공격 정보 테이블(예정)




페이스북 계정 테이블 (임시)
CREATE TABLE `facebookaccount` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`acountID` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`nickName` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`gameID` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
;


우편함 테이블
CREATE TABLE `gameidmailbox` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`sender` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`receiver` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`title` VARCHAR(30) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`content` VARCHAR(300) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`timeStamp` VARCHAR(300) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`slot1` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`slot2` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`slot3` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`slot4` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`slot5` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=58
;

계정별 캐릭터 보유 테이블
CREATE TABLE `gameidownscharactor` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`gameID` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`chrID` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`potentialAverage` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`meeleeatk` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`magicAttack` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`defense` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`mdefense` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`critical` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`healthy` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`lv` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`tear` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`atkPotential` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`matkPotential` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`defensPotential` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`mdefensPotential` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`criticalRatePotential` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`healthyPotential` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`jobCode` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`aliasName` VARCHAR(50) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	`rep` VARCHAR(10) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	`Party` VARCHAR(50) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	`partynum` VARCHAR(50) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=2107
;


게임 아이디 테이블
CREATE TABLE `gameidtbl` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`gameID` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`gameNick` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`halfCredit` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`fullCredit` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`playTime` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`lastConnect` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`playerRank` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`mailboxIndex` INT(11) NOT NULL DEFAULT '0',
	`potenAverage` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`ssClearNum` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`accountPermission` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=703
;



구글 계정 테이블
CREATE TABLE `googleaccount` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`acountID` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`nickName` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`gameID` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=703
;



잡테이블
CREATE TABLE `job` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`chrID` VARCHAR(20) NOT NULL COLLATE 'utf8mb4_general_ci',
	`jobCode` VARCHAR(10) NOT NULL COLLATE 'utf8mb4_general_ci',
	`jobBonusCode` VARCHAR(10) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=14
;








관리 테이블
CREATE TABLE `manager` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`UserID` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`Psswd` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`Level` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=4
;



세션키 테이블
CREATE TABLE `session` (
	`_id` INT(11) NOT NULL AUTO_INCREMENT,
	`sessionKey` VARCHAR(250) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`userID` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',
	`siteID` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`_id`) USING BTREE,
	UNIQUE INDEX `sessionKey` (`sessionKey`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=703
;








RunSQL
MEELE -> 근접
PARTY -> 광역
RANGE -> 원거리

PHYSICS -> 물리 공격
MAGIC_속성명 -> 마법 공격
CompositionB -> 혼합러 

첫 3자리
000 -> 플레이어 블
001 -> 에네미 
002 -> 중보스 
003 -> 보스

중간 3자리
000 -> 클레릭
001 -> 나이트
002 -> 매지션
003 -> 드워프
004 -> 로그

마지막 3자리
000 ~ 010 -> Tear 1스킬
011 ~ 020 -> Tear 2스킬
021 ~ 030 -> Tear 3스킬
031 ~ 040 -> Tear 4스킬
.
.
.
111 ~ 120 -> Tear 12스킬
121 ~ 130 -> Tear 13스킬
131 ~ 140 -> Tear 14스킬
141 ~ 150 -> Tear 15스킬
.
.
.
991 ~ 999 -> Tear 99스킬

skill
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000000000", "RANGE", "MAGIC_THUNDER", "0",       "0",       "1.5",       "BarrageArrowHoly",      "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000001000", "MEELE",     "PHYSICS",    "5",      "0",       "1.5",         "FX_SwordSlash_01",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000002000", "RANGE",  "MAGIC",  "10",      "0",       "1.5",         "FX_Fireball_Shooting_Straight_01",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000003000", "MEELE",     "PHYSICS",    "10",      "0",       "1.5",         "FX_SwordSlash_01",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000004000", "MEELE",     "PHYSICS",    "10",      "0",       "1.5",         "CritSpikeExplosionPurple",     "",         "",             "");


skill -> 플레이어 특수 공격 -> 마지막 스킬 번호
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000000010", "MEELE",     "MAGIC_HEAL",    "0",      "0",       "1.5",         "HealOnce",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000001010", "MEELE",     "PHYSICS_PIERCING",    "10",      "0",       "1.5",         "SwordImpactEpicGold",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000002010", "PARTY",     "MAGIC_MULTIPLY",    "0.5",      "0",       "2.5",         "GroundSlamBlue",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000003010", "MEELE",     "PHYSICS",    "15",      "0",       "1.5",         "StoneExplosion",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000004010", "MEELE",     "PHYSICS_FATALBLESSING",    "10",      "40",       "1.5",         "CritSpikeExplosionPurple",    "",         "",             "");


skill -> 플레이어 특수 공격 -> Tear 3
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000000030", "PARTY",     "MAGIC_HEAL_MULTIPLY",    "0.5",      "0",       "2.5",         "FX_RainbowSparkle_01",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000001030", "PARTY",     "PHYSICS_MULTIPLY",    "0.5",      "0",       "2.5",         "SwordVolleyGold 3 3 3 ",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000002030", "PARTY",     "MAGIC_MULTIPLY",    "0.5",      "0",       "2.5",         "BarrageShell",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000003030", "MEELE",     "PHYSICS",    "30",      "0",       "1.5",         "CleaveStone",    "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("000004030", "MEELE",     "PHYSICS_FATALBLESSING",    "15",      "50",       "1.5",         "SkullExplosionYellow 4 4 4",    "",         "",             "");





몬스터 skill

첫 3자리
000 -> 플레이어 블
001 -> 에네미 
002 -> 중보스 
003 -> 보스

중간 4자리
0000 -> 몬스터A
0001 -> 몬스터B
0002 -> 몬스터C
0003 -> 몬스터D
0004 -> 몬스터E

마지막 2자리
00 ~ 99 몬스터 스킬

일반 스킬
일반 몬스터
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("001000000", "MEELE", "PHYSICS", "2",       "0",       "1.5",       "FX_SwordSlash_01",      "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("001000100", "MEELE", "PHYSICS", "3",       "0",       "1.5",       "FX_SwordSlash_01",      "",         "",             "");       

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("001000200", "MEELE", "MAGIC", "2",       "0",       "1.5",       "BloodDebuff",      "",         "",             "");       

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("001000300", "MEELE", "PHYSICS", "3",       "0",       "1.5",       "AcidExplosion",      "",         "",             "");                     

강화 몬스터
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("002000000", "MEELE", "PHYSICS", "5",       "0",       "1.5",       "ChainTargetFire",      "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("002000100", "MEELE", "PHYSICS", "5",       "0",       "1.5",       "ChainTargetFire",      "",         "",             "");       

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("002000200", "MEELE", "MAGIC", "2",       "0",       "1.5",       "BarrageArrowShadow",      "",         "",             "");       



보스 몬스터
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("003000000", "MEELE", "PHYSICS", "5",       "0",       "1.5",       "FX_ShardRock_Explosion_01",      "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("003000100", "MEELE", "MAGIC", "5",       "0",       "1.5",       "FX_ShardMagic_Explosion_01",      "",         "",             "");       

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("003000200", "MEELE", "PHYSICS", "5",       "0",       "1.5",       "FX_ShardVine_Shooting_01",      "",         "",             "");     

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("003000300", "MEELE", "MAGIC", "5",       "0",       "1.5",       "ShadowPurpleExplosion",      "",         "",             ""); 
                      
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("003000400", "MEELE", "PHYSICS", "5",       "0",       "1.5",       "CleaveDark",      "",         "",             ""); 









몬스터 특수 공격 
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("001000001", "MEELE", "PHYSICS", "4",       "0",       "1.5",       "CritSpikeExplosionRed",      "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("001000101", "MEELE", "PHYSICS", "5",       "0",       "1.5",       "CritSpikeExplosionRed",      "",         "",             "");       

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("001000201", "PARTY", "MAGIC", "-15",       "0",       "1.5",       "DamageAuraShadow",      "",         "",             "");       

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("001000301", "MEELE", "PHYSICS", "3",       "0",       "1.5",       "FX_Fire_Explosion_01",      "",         "",             "");                     



강화 몬스터
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("002000001", "PARTY", "PHYSICS", "5",       "0",       "2.5",       "FX_ShardRock_Explosion_01",      "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("002000101", "MEELE", "PHYSICS", "5",       "0",       "1.5",       "BarrageArrowShadow",      "",         "",             "");       

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("002000201", "PARTY", "MAGIC", "2",       "0",       "2.5",       "DeathFire",      "",         "",             "");       


보스 몬스터
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("003000001", "MEELE", "PHYSICS", "15",       "0",       "1.5",       "FX_GroundCrack_Blast_01",      "",         "",             ""); 

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("003000101", "PARTY", "PHYSICS", "-10",       "0",       "2.5",       "SpikeWaveSapphire",      "",         "",             "");       

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("003000201", "PARTY", "PHYSICS", "-10",       "0",       "2.5",       "SpikeWaveStoneBig",      "",         "",             "");     

insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("003000301", "PARTY", "MAGIC", "5",       "0",       "1.5",       "DeathAcid",      "",         "",             ""); 
                      
insert into skills(skillNumID, skillType, attackProperty, damage, subDamage, skillRunDuration, attackFXSlot1, attackFXSlot2, attackFXSlot3, attackFXSlot4) values
                    ("003000401", "PARTY", "PHYSICS", "5",       "0",       "1.5",       "FX_Explosion_Large_Dark_01",      "",         "",             ""); 



 









skilldetailinfotbl -> 유저기준 티어3 특수 기술

insert into skilldetailinfotbl(skillNumID, name, description) values
				("000000030", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("000001030", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("000002030", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("000003030", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("000004030", "", "뒤틀린 황천의 의상");






skilldetailinfotbl -> 몬스터 기준 일반 기술

insert into skilldetailinfotbl(skillNumID, name, description) values
				("001000000", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("001000100", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("001000200", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("001000300", "", "뒤틀린 황천의 의상");

강화몹
insert into skilldetailinfotbl(skillNumID, name, description) values
				("002000000", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("002000100", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("002000200", "", "뒤틀린 황천의 의상");

보스 몹
insert into skilldetailinfotbl(skillNumID, name, description) values
				("003000000", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("003000100", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("003000200", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("003000300", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("003000400", "", "뒤틀린 황천의 의상");




특수 기술

insert into skilldetailinfotbl(skillNumID, name, description) values
				("001000001", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("001000101", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("001000201", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("001000301", "", "뒤틀린 황천의 의상");




insert into skilldetailinfotbl(skillNumID, name, description) values
				("002000001", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("002000101", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("002000201", "", "뒤틀린 황천의 의상");

insert into skilldetailinfotbl(skillNumID, name, description) values
				("003000001", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("003000101", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("003000201", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("003000301", "", "뒤틀린 황천의 의상");
insert into skilldetailinfotbl(skillNumID, name, description) values
				("003000401", "", "뒤틀린 황천의 의상");



