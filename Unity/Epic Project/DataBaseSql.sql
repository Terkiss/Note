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


캐릭터 공격 정보 테이블
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



