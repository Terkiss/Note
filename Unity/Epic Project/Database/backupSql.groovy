-- --------------------------------------------------------
-- 호스트:                          101.79.9.44
-- 서버 버전:                        10.6.3-MariaDB - mariadb.org binary distribution
-- 서버 OS:                        Win64
-- HeidiSQL 버전:                  11.1.0.6116
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- 테이블 dearmycastle.character_skill_info 구조 내보내기
CREATE TABLE IF NOT EXISTS `character_skill_info` (
  `_id` int(11) NOT NULL AUTO_INCREMENT,
  `chrID` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '0',
  `skillNumID` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '0',
  PRIMARY KEY (`_id`),
  KEY `skillRef` (`skillNumID`),
  CONSTRAINT `skillRef` FOREIGN KEY (`skillNumID`) REFERENCES `skills` (`skillNumID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb3;

-- 테이블 데이터 dearmycastle.character_skill_info:~35 rows (대략적) 내보내기
/*!40000 ALTER TABLE `character_skill_info` DISABLE KEYS */;
INSERT INTO `character_skill_info` (`_id`, `chrID`, `skillNumID`) VALUES
	(4, '01000000', '000000000'),
	(5, '01000001', '000001000'),
	(6, '01000002', '000002000'),
	(7, '01000003', '000003000'),
	(8, '01000004', '000004000'),
	(9, '01000000', '000000010'),
	(10, '01000001', '000001010'),
	(11, '01000002', '000002010'),
	(12, '01000003', '000003010'),
	(13, '01000004', '000004010'),
	(14, '01000004', '000004010'),
	(15, '02000000', '001000000'),
	(16, '02000001', '001000100'),
	(17, '02000002', '001000200'),
	(18, '02000003', '001000300'),
	(19, '03000000', '002000000'),
	(20, '03000001', '002000100'),
	(21, '03000002', '002000200'),
	(22, '04000000', '003000000'),
	(23, '04000001', '003000100'),
	(24, '04000002', '003000200'),
	(25, '04000003', '003000300'),
	(26, '04000004', '003000400'),
	(27, '02000000', '001000001'),
	(28, '02000001', '001000101'),
	(29, '02000002', '001000201'),
	(30, '02000003', '001000301'),
	(31, '03000000', '002000001'),
	(32, '03000001', '002000101'),
	(33, '03000002', '002000201'),
	(34, '04000000', '003000001'),
	(35, '04000001', '003000101'),
	(36, '04000002', '003000201'),
	(37, '04000003', '003000301'),
	(38, '04000004', '003000401');
/*!40000 ALTER TABLE `character_skill_info` ENABLE KEYS */;

-- 테이블 dearmycastle.skilldetailinfotbl 구조 내보내기
CREATE TABLE IF NOT EXISTS `skilldetailinfotbl` (
  `skillNumID` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `description` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  PRIMARY KEY (`skillNumID`),
  CONSTRAINT `FK_skilldetailinfotbl_skills` FOREIGN KEY (`skillNumID`) REFERENCES `skills` (`skillNumID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 테이블 데이터 dearmycastle.skilldetailinfotbl:~39 rows (대략적) 내보내기
/*!40000 ALTER TABLE `skilldetailinfotbl` DISABLE KEYS */;
INSERT INTO `skilldetailinfotbl` (`skillNumID`, `name`, `description`) VALUES
	('000000000', '번개', '원거리  마법 (번개)공격'),
	('000000010', '티어 1 특수 공격', '뒤틀린 황천의 포셔 의상'),
	('000000030', '티어 3 특수 공격', '뒤틀린 황천의 의상'),
	('000001000', '근접', '근접 물리공격'),
	('000001010', '티어 1 특수 공격', '뒤틀린 황천의 의상'),
	('000001030', '티어 3 특수 공격', '뒤틀린 황천의 의상'),
	('000002000', '원거리마법', '원거리 마법공격'),
	('000002010', '티어 1 특수 공격', '뒤틀린 황천의 의상'),
	('000002030', '티어 3 특수 공격', '뒤틀린 황천의 의상'),
	('000003000', '1인근접', '강력한 1인 물리공격'),
	('000003010', '티어 1 특수 공격', '뒤틀린 황천의 의상'),
	('000003030', '티어 3 특수 공격', '뒤틀린 황천의 의상'),
	('000004000', '근접', '근접 물리공격 '),
	('000004010', '티어 1 특수 공격', '뒤틀린 황천의 의상'),
	('000004030', '티어 3 특수 공격', '뒤틀린 황천의 의상'),
	('001000000', '', '뒤틀린 황천의 의상'),
	('001000001', '', '뒤틀린 황천의 의상'),
	('001000100', '', '뒤틀린 황천의 의상'),
	('001000101', '', '뒤틀린 황천의 의상'),
	('001000200', '', '뒤틀린 황천의 의상'),
	('001000201', '', '뒤틀린 황천의 의상'),
	('001000300', '', '뒤틀린 황천의 의상'),
	('001000301', '', '뒤틀린 황천의 의상'),
	('002000000', '', '뒤틀린 황천의 의상'),
	('002000001', '', '뒤틀린 황천의 의상'),
	('002000100', '', '뒤틀린 황천의 의상'),
	('002000101', '', '뒤틀린 황천의 의상'),
	('002000200', '', '뒤틀린 황천의 의상'),
	('002000201', '', '뒤틀린 황천의 의상'),
	('003000000', '', '뒤틀린 황천의 의상'),
	('003000001', '', '뒤틀린 황천의 의상'),
	('003000100', '', '뒤틀린 황천의 의상'),
	('003000101', '', '뒤틀린 황천의 의상'),
	('003000200', '', '뒤틀린 황천의 의상'),
	('003000201', '', '뒤틀린 황천의 의상'),
	('003000300', '', '뒤틀린 황천의 의상'),
	('003000301', '', '뒤틀린 황천의 의상'),
	('003000400', '', '뒤틀린 황천의 의상'),
	('003000401', '', '뒤틀린 황천의 의상');
/*!40000 ALTER TABLE `skilldetailinfotbl` ENABLE KEYS */;

-- 테이블 dearmycastle.skills 구조 내보내기
CREATE TABLE IF NOT EXISTS `skills` (
  `_id` int(11) NOT NULL AUTO_INCREMENT,
  `skillNumID` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '0' COMMENT '스킬아이디',
  `skillType` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '0' COMMENT '스킬타입',
  `attackProperty` varchar(50) CHARACTER SET utf8mb4 DEFAULT '' COMMENT '공격 속성',
  `damage` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '0' COMMENT '데미지',
  `subDamage` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '0' COMMENT '추가효과',
  `skillRunDuration` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '0' COMMENT '스킬 딜레이',
  `soundFX` varchar(50) DEFAULT NULL,
  `attackFXSlot1` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '0' COMMENT '슬롯',
  `attackFXSlot2` varchar(50) CHARACTER SET utf8mb4 DEFAULT '' COMMENT '슬롯2',
  `attackFXSlot3` varchar(50) CHARACTER SET utf8mb4 DEFAULT '' COMMENT '슬롯3',
  `attackFXSlot4` varchar(50) CHARACTER SET utf8mb4 DEFAULT '' COMMENT '슬롯4',
  PRIMARY KEY (`_id`),
  UNIQUE KEY `skillNumID` (`skillNumID`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb3;

-- 테이블 데이터 dearmycastle.skills:~39 rows (대략적) 내보내기
/*!40000 ALTER TABLE `skills` DISABLE KEYS */;
INSERT INTO `skills` (`_id`, `skillNumID`, `skillType`, `attackProperty`, `damage`, `subDamage`, `skillRunDuration`, `soundFX`, `attackFXSlot1`, `attackFXSlot2`, `attackFXSlot3`, `attackFXSlot4`) VALUES
	(1, '000000000', 'RANGE', 'MAGIC_THUNDER', '0', '0', '1.5', 'Special Attack 05', 'BarrageArrowHoly', '', '', ''),
	(2, '000001000', 'MEELE', 'PHYSICS', '5', '0', '1.5', 'Special Attack 07', 'FX_SwordSlash_01', '', '', ''),
	(3, '000002000', 'RANGE', 'MAGIC', '10', '0', '1.5', 'Cast 10', 'FX_Fireball_Shooting_Straight_01', '', '', ''),
	(4, '000003000', 'MEELE', 'PHYSICS', '10', '0', '1.5', 'Special Attack 13', 'FX_SwordSlash_01', '', '', ''),
	(5, '000004000', 'MEELE', 'PHYSICS', '10', '0', '1.5', 'Special Attack 22', 'CritSpikeExplosionPurple', '', '', ''),
	(6, '000000010', 'MEELE', 'MAGIC_HEAL', '0', '0', '1.5', 'levelup1', 'HealOnce', '', '', ''),
	(7, '000001010', 'MEELE', 'PHYSICS_PIERCING', '10', '0', '1.5', 'Buff Defense 08', 'SwordImpactEpicGold', '', '', ''),
	(8, '000002010', 'PARTY', 'MAGIC_MULTIPLY', '0.5', '0', '2.5', 'Cast 08', 'GroundSlamBlue', '', '', ''),
	(9, '000003010', 'MEELE', 'PHYSICS', '15', '0', '1.5', 'Fire Spell 18', 'StoneExplosion', '', '', ''),
	(10, '000004010', 'MEELE', 'PHYSICS_FATALBLESSING', '10', '40', '1.5', 'Special Attack 06', 'CritSpikeExplosionPurple', '', '', ''),
	(11, '000000030', 'PARTY', 'MAGIC_HEAL_MULTIPLY', '0.5', '0', '2.5', 'levelup1', 'FX_RainbowSparkle_01', '', '', ''),
	(12, '000001030', 'PARTY', 'PHYSICS_MULTIPLY', '0.5', '0', '2.5', 'Buff Defense 08', 'SwordVolleyGold 3 3 3 ', '', '', ''),
	(13, '000002030', 'PARTY', 'MAGIC_MULTIPLY', '0.5', '0', '2.5', 'Cast 08', 'BarrageShell', '', '', ''),
	(14, '000003030', 'MEELE', 'PHYSICS', '30', '0', '1.5', 'Fire Spell 18', 'CleaveStone', '', '', ''),
	(15, '000004030', 'MEELE', 'PHYSICS_FATALBLESSING', '15', '50', '1.5', 'Special Attack 06', 'SkullExplosionYellow 4 4 4', '', '', ''),
	(16, '001000000', 'MEELE', 'PHYSICS', '2', '0', '1.5', 'Lightning Spell 07', 'FX_SwordSlash_01', '', '', ''),
	(17, '001000100', 'MEELE', 'PHYSICS', '3', '0', '1.5', 'Lightning Spell 07', 'FX_SwordSlash_01', '', '', ''),
	(18, '001000200', 'MEELE', 'MAGIC', '2', '0', '1.5', 'Shadow Spell 09', 'BloodDebuff', '', '', ''),
	(19, '001000300', 'MEELE', 'PHYSICS', '3', '0', '1.5', 'Lightning Spell 07', 'AcidExplosion', '', '', ''),
	(20, '002000000', 'MEELE', 'PHYSICS', '5', '0', '1.5', 'Lightning Spell 07', 'ChainTargetFire', '', '', ''),
	(21, '002000100', 'MEELE', 'PHYSICS', '5', '0', '1.5', 'Lightning Spell 07', 'ChainTargetFire', '', '', ''),
	(22, '002000200', 'MEELE', 'MAGIC', '2', '0', '1.5', 'Nature Spell 02', 'BarrageArrowShadow', '', '', ''),
	(23, '003000000', 'MEELE', 'PHYSICS', '5', '0', '1.5', 'Lightning Spell 07', 'FX_ShardRock_Explosion_01', '', '', ''),
	(24, '003000100', 'MEELE', 'MAGIC', '5', '0', '1.5', 'Shadow Attack 3', 'FX_ShardMagic_Explosion_01', '', '', ''),
	(25, '003000200', 'MEELE', 'PHYSICS', '5', '0', '1.5', 'Lightning Spell 07', 'FX_ShardVine_Shooting_01', '', '', ''),
	(26, '003000300', 'MEELE', 'MAGIC', '5', '0', '1.5', 'Shadow Attack 3', 'ShadowPurpleExplosion', '', '', ''),
	(27, '003000400', 'MEELE', 'PHYSICS', '5', '0', '1.5', 'Lightning Spell 07', 'CleaveDark', '', '', ''),
	(28, '001000001', 'MEELE', 'PHYSICS', '4', '0', '1.5', 'Nature Spell 04', 'CritSpikeExplosionRed', '', '', ''),
	(29, '001000101', 'MEELE', 'PHYSICS', '5', '0', '1.5', 'Nature Spell 04', 'CritSpikeExplosionRed', '', '', ''),
	(30, '001000201', 'PARTY', 'MAGIC', '-15', '0', '1.5', 'Nature Spell 02', 'DamageAuraShadow', '', '', ''),
	(31, '001000301', 'MEELE', 'PHYSICS', '3', '0', '1.5', 'Nature Spell 03', 'FX_Fire_Explosion_01', '', '', ''),
	(32, '002000001', 'PARTY', 'PHYSICS', '5', '0', '2.5', 'Shadow Spell 15', 'FX_ShardRock_Explosion_01', '', '', ''),
	(33, '002000101', 'MEELE', 'PHYSICS', '5', '0', '1.5', 'Nature Spell 02', 'BarrageArrowShadow', '', '', ''),
	(34, '002000201', 'PARTY', 'MAGIC', '2', '0', '2.5', 'Shadow Spell 10', 'DeathFire', '', '', ''),
	(35, '003000001', 'MEELE', 'PHYSICS', '15', '0', '1.5', 'Shadow Attack 2', 'FX_GroundCrack_Blast_01', '', '', ''),
	(36, '003000101', 'PARTY', 'PHYSICS', '-10', '0', '2.5', 'Shadow Attack 7', 'SpikeWaveSapphire', '', '', ''),
	(37, '003000201', 'PARTY', 'PHYSICS', '-10', '0', '2.5', 'Shadow Attack 2', 'SpikeWaveStoneBig', '', '', ''),
	(38, '003000301', 'PARTY', 'MAGIC', '5', '0', '1.5', 'Shadow Spell 15', 'DeathAcid', '', '', ''),
	(39, '003000401', 'PARTY', 'PHYSICS', '5', '0', '1.5', 'Shadow Spell 15', 'FX_Explosion_Large_Dark_01', '', '', '');
/*!40000 ALTER TABLE `skills` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
